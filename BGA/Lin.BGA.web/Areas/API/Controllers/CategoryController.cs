using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lin.BGA.BLLFactory;
using Lin.BGA.IBLL;
using Lin.BGA.Model;



namespace Lin.BGA.web.Areas.API.Controllers
{
    public class CategoryController : Controller
    {
        // GET: API/Category
        public ActionResult Index()
        {
            return View();
        }

        protected ICategoryInfoService CategoryBLL = AbstractFactory.CreateCategoryInfoService();
        public JsonResult GetList()
        {
            var result = CategoryBLL.GetList(a => a.Enable).OrderBy(a => a.SortID).ThenBy(a => a.ID).Select(a => new {
                a.ID,
                a.Name,
                MusicInfo = a.MusicInfo.Where(m => m.Enable).OrderByDescending(m => m.SortID).ThenBy(m => m.ID).Select(m => new {
                    m.ID,
                    m.Name,
                    m.PlayTime,
                    m.SRC
                })
            });
            return Json(new APIJson(0, "", result),JsonRequestBehavior.AllowGet);
        }

    }
}