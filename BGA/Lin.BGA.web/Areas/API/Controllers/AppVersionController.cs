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
    public class AppVersionController : Controller
    {
        protected IAppVersionInfoService AppVersionBLL = AbstractFactory.CreateAppVersionInfoService();
        public ActionResult GetLast()
        {
           var info= AppVersionBLL.GetList(a => true).OrderByDescending(a => a.ID).FirstOrDefault();
            return Json(new APIJson(0, "", info), JsonRequestBehavior.AllowGet);
        }


    }
}