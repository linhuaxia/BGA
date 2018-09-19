using Lin.BGA.BLLFactory;
using Lin.BGA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Lin.BGA.Model;
using Tool;
using System.Dynamic;
using System.IO;

namespace Lin.BGA.web.Controllers
{
    public class AppVersionController : BaseMPController
    {

        public ActionResult Index(int page = 1)
        {
            var list = AppVersionBLL.GetList(p => true);
            list = list.OrderByDescending(p => p.ID );
            IPagedList<AppVersionInfo> result = list.ToPagedList(page, PageSize);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AppVersionInfo info)
        {
            if (string.IsNullOrEmpty(info.Version))
            {
                return Json(new APIJson(-1,"名称未填写"));
            }

            HttpPostedFileBase FileMain = Request.Files["FileMain"];
            if (null == FileMain)
            {
                return Json(new APIJson(-1, "请选择文件"));
            }
            string FilePathRelative = "/Content/AppVersion/";
            string FileName = info.Version + ".zip";
            string FileFullPath = Server.MapPath(FilePathRelative);
            if (!Directory.Exists(FileFullPath))
            {
                Directory.CreateDirectory(FileFullPath);
            }


            FileMain.SaveAs(FileFullPath+FileName);

            info.SRC = FilePathRelative + FileName;
            info.CreateDate = DateTime.Now;
            AppVersionBLL.Create(info);
            if (info.ID > 0)
            {
                return Json(new APIJson(0, "添加成功",new { info.ID,info.Version}));
            }
            return Json(new APIJson(-1, "添加失败"));
        }

        public ActionResult Edit(int id)
        {
            AppVersionInfo info = AppVersionBLL.GetList(p => p.ID == id).FirstOrDefault();


            return View(info);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(AppVersionInfo info)
        {
            AppVersionInfo infoExist = AppVersionBLL.GetList(p => p.Version == info.Version).FirstOrDefault();
            if (infoExist != null && infoExist.ID != info.ID)
            {
                return Json(new APIJson(-1, "版本已存在"));
            }
            if (string.IsNullOrEmpty(info.Version))
            {
                return Json(new APIJson(-1, "版本未填写"));
            }
            if (string.IsNullOrEmpty(info.Version.Trim()))
            {
                return Json(new APIJson(-1, "版本不能是空格，请正确填写"));
            }
            infoExist = AppVersionBLL.GetList(p => p.ID == info.ID).FirstOrDefault();
            if (null == infoExist)
            {
                return Json(new APIJson(-1, "parms error"));
            }
            infoExist.Version = info.Version;
            infoExist.Detail = info.Detail;

            if (AppVersionBLL.Edit(infoExist))
            {
                return Json(new APIJson(0, "提交成功"));
            }
            return Json(new APIJson(-1, "提交失败"));
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var info = AppVersionBLL.GetList(p => p.ID == id).FirstOrDefault();
            if (null == info)
            {
                return Json(new APIJson(-1, "删除失败，参数有误"));
            }
            if (AppVersionBLL.Delete(info))
            {
                return Json(new APIJson(0, "删除成功"));
            }
            return Json(new APIJson(-1, "删除失败，请重试"));
        }

    }
}
