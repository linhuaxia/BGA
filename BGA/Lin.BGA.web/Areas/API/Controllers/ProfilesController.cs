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
    public class ProfilesController : Controller
    {
        // GET: API/Profiles
        public ActionResult Index()
        {
            return View();
        }

        protected IProfilesInfoService ProfilesBLL = AbstractFactory.CreateProfilesInfoService();
        public JsonResult GetAllConfig()
        {
            var result = ProfilesBLL.GetList(a => true);
            return Json(new APIJson(0, "", result),JsonRequestBehavior.AllowGet);
        }
    }
}