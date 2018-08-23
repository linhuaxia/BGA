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

namespace Lin.BGA.web.Controllers
{
    public class CategoryController : BaseMPController
    {

        public ActionResult Index(int page = 1)
        {
            var list = CategoryBLL.GetList(p => true);
            list = list.OrderByDescending(p => p.Enable ).ThenByDescending(p=>p.ID);
            IPagedList<CategoryInfo> result = list.ToPagedList(page, PageSize);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CategoryInfo info)
        {
            CategoryInfo infoExist = CategoryBLL.GetList(p => p.Name == info.Name).FirstOrDefault();
            if (null != infoExist)
            {
                return Json(new APIJson(-1,"名称已存在"));
            }
            if (string.IsNullOrEmpty(info.Name))
            {
                return Json(new APIJson(-1,"名称未填写"));
            }
            if (string.IsNullOrEmpty(info.Name.Trim()))
            {
                return Json(new APIJson(-1, "名称不能是空格，请正确填写"));
            }
            CategoryBLL.Create(info);
            if (info.ID > 0)
            {
                return Json(new APIJson(0, "添加成功",new { info.ID,info.Name}));
            }
            return Json(new APIJson(-1, "添加失败"));
        }

        public ActionResult Edit(int id)
        {
            CategoryInfo info = CategoryBLL.GetList(p => p.ID == id).FirstOrDefault();


            return View(info);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CategoryInfo info)
        {
            CategoryInfo infoExist = CategoryBLL.GetList(p => p.Name == info.Name).FirstOrDefault();
            if (infoExist != null && infoExist.ID != info.ID)
            {
                return Json(new APIJson(-1, "名称已存在"));
            }
            if (string.IsNullOrEmpty(info.Name))
            {
                return Json(new APIJson(-1, "名称未填写"));
            }
            if (string.IsNullOrEmpty(info.Name.Trim()))
            {
                return Json(new APIJson(-1, "名称不能是空格，请正确填写"));
            }
            infoExist = CategoryBLL.GetList(p => p.ID == info.ID).FirstOrDefault();
            if (null == infoExist)
            {
                return Json(new APIJson(-1, "parms error"));
            }

            infoExist.Name = info.Name;
            infoExist.Enable = info.Enable;
            if (CategoryBLL.Edit(infoExist))
            {
                return Json(new APIJson(0, "提交成功", info));
            }
            return Json(new APIJson(-1, "提交失败", info));
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var info = CategoryBLL.GetList(p => p.ID == id).FirstOrDefault();
            if (null == info)
            {
                return Json(new APIJson(-1, "删除失败，参数有误"));
            }
            if (CategoryBLL.Delete(info))
            {
                return Json(new APIJson(0, "删除成功"));
            }
            return Json(new APIJson(-1, "删除失败，请重试"));
        }

    }
}
