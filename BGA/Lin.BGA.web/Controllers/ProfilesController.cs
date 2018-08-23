using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

using Tool;
using Lin.BGA.Model;
using Lin.BGA.BLLFactory;
using Lin.BGA.IBLL;

namespace Lin.BGA.web.Controllers
{
    public class ProfilesController : BaseMPController
    {
        // GET: MP/ProfilesInfo
        public ActionResult Index(int page = 1)
        {
           
            return View();
        }

        public ActionResult MainSetting()
        {
            ViewBag.EnableUpdateTimeBegin = ProfilesBLL.Get("EnableUpdateTimeBegin", true);
            ViewBag.EnableUpdateTimeEnd = ProfilesBLL.Get("EnableUpdateTimeEnd", true);
            ViewBag.EnableUpdateTimeInterval = ProfilesBLL.Get("EnableUpdateTimeInterval", true);
            return View();
        }
        [HttpPost]
        public ActionResult MainSetting(int TimeStamp)
        {
            ProfilesInfo EnableUpdateTimeBegin = ProfilesBLL.Get("EnableUpdateTimeBegin", true);
            ProfilesInfo EnableUpdateTimeEnd = ProfilesBLL.Get("EnableUpdateTimeEnd", true);
            ProfilesInfo EnableUpdateTimeInterval = ProfilesBLL.Get("EnableUpdateTimeInterval", true);

            EnableUpdateTimeBegin.Value = Function.GetRequestString("EnableUpdateTimeBegin");
            EnableUpdateTimeEnd.Value = Function.GetRequestString("EnableUpdateTimeEnd");
            EnableUpdateTimeInterval.Value = Function.GetRequestString("EnableUpdateTimeInterval");


            ProfilesBLL.Edit(EnableUpdateTimeBegin);
            ProfilesBLL.Edit(EnableUpdateTimeEnd);
            ProfilesBLL.Edit(EnableUpdateTimeInterval);
            return Json(new APIJson(0, "更新成功"));
        }


    }
}
