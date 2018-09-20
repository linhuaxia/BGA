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
using Lin.BGA.web.Controllers;
using System.Dynamic;
using System.Data.Entity;
using System.Data;

namespace Lin.BGA.web.Controllers
{
    public class MusicController : BaseMPController
    {
        public ActionResult Index(int page = 1)
        {
            //return new Wechat.Controllers.MusicController().Index(page);
            IQueryable<MusicInfo> list = GetListData();
            IPagedList<MusicInfo> result = list.ToPagedList(page, PageSize);
            return View(result);
        }

        private IQueryable<MusicInfo> GetListData()
        {
            var list = MusicBLL.GetList(p =>true);
            string Name = Function.GetRequestString("Name");
            if (!string.IsNullOrEmpty(Name))
            {
                list = list.Where(a => a.Name.Contains(Name));
                ViewBag.TxtName = Name;
            }

            list = list.OrderBy(p => p.SortID).ThenBy(a=>a.ID);
            return list;
        }

        public ActionResult Create()
        {
            GetSelectList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(MusicInfo info)
        {
            if (string.IsNullOrEmpty(info.Name))
            {
                return Json(new APIJson("请填写名称"));
            }
            if (info.CategoryID <= 0)
            {
                return Json(new APIJson("请选择分类"));
            }

            HttpPostedFileBase FileMain = Request.Files["FileMain"];
            if (null == FileMain)
            {
                return Json(new APIJson(-1, "请选择音频文件"));
            }
            info.SRC = "/Content/File/Music/" + Guid.NewGuid().ToString() + FileMain.FileName.Substring(FileMain.FileName.LastIndexOf("."));

            FileMain.SaveAs(Server.MapPath(info.SRC));



            if (MusicBLL.Create(info).ID > 0)
            {
                return Json(new APIJson(0, "提交成功", new { info.ID }));
            }
            return Json(new APIJson(-1, "提交失败，请重试"));
        }
        private void GetSelectList()
        {
            ViewBag.listPlanCategory = CategoryBLL.GetList(a => a.Enable).OrderByDescending(a => a.ID)
                .ToList().Select(a => new SelectListItem() { Text = a.Name, Value = a.ID.ToString() });
        }


        public ActionResult Edit(int id)
        {
            GetSelectList();
            MusicInfo info = MusicBLL.GetList(p => p.ID == id).FirstOrDefault();

            return View(info);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MusicInfo info)
        {
            MusicInfo infoExist = MusicBLL.GetList(p => p.ID == info.ID).FirstOrDefault();
            if (string.IsNullOrEmpty(info.Name))
            {
                return Json(new APIJson("请填写名称"));
            }
            if (info.CategoryID <= 0)
            {
                return Json(new APIJson("请选择分类"));
            }
            HttpPostedFileBase FileMain = Request.Files["FileMain"];
            if (null != FileMain)
            {
                info.SRC = "/Content/File/Music/" + Guid.NewGuid().ToString() + FileMain.FileName.Substring(FileMain.FileName.LastIndexOf("."));
                FileMain.SaveAs(Server.MapPath(info.SRC));
                infoExist.SRC = info.SRC;
            }
            if (info.PlayTime<=0)
            {
                info.PlayTime = 1;
            }

            infoExist.CategoryID = info.CategoryID;
            infoExist.Name = info.Name;
            infoExist.SortID = info.SortID;
            infoExist.Enable = info.Enable;
            infoExist.PlayTime = info.PlayTime;


            if (MusicBLL.Edit(infoExist))
            {
                return Json(new APIJson(0, "提交成功"));
            }
            return Json(new APIJson(-1, "提交失败，请重试"));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var info = MusicBLL.GetList(p => p.ID == id).FirstOrDefault();
            if (null == info)
            {
                return Json(new APIJson(-1, "删除失败，参数有误"));
            }
            if (MusicBLL.Delete(info))
            {
                return Json(new APIJson(0, "删除成功"));
            }
            return Json(new APIJson(-1, "删除失败，请重试"));
        }



    }
}
