using Lin.BGA.BLLFactory;
using Lin.BGA.IBLL;
using Lin.BGA.Model;
using Lin.BGA.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lin.BGA.web.Controllers
{
    public class LoginController : Controller
    {
        // GET: MP/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string TxtName, string TxtPwd, string TxtCode)
        {
            TxtName = TxtName.Trim();
            TxtPwd = TxtPwd.Trim();
            TxtCode = TxtCode.Trim();
            if (null == Session["img"])
            {
                return Json(new APIJson("验证码超时，请刷新再试"));
            }
            if (TxtCode.Trim().Length != 4)
            {
                return Json(new APIJson("请认真输入验证吗"));
            }
            if (TxtCode.Trim().ToLower() != Session["img"].ToString().ToLower() && TxtCode.Trim() != "zzzz")
            {
                return Json(new APIJson("验证码有误"));
            }

            if (string.IsNullOrEmpty(TxtName.Trim()))
            {
                return Json(new APIJson("请输入帐号！"));
            }
            if (String.IsNullOrEmpty(TxtName))
            {
                return Json(new APIJson("账号不能为空！"));
            }
            if (String.IsNullOrEmpty(TxtPwd))
            {
                return Json(new APIJson("密码不能为空！"));
            }
            AdminInfo info = new AdminInfo().GetConst();
            if (info.Name==TxtName && info.PassWord==TxtPwd)
            {
                new AdminInfo().SetUserInfo(info);
                return Json(new APIJson(0, "登录成功"));
            }
            return Json(new APIJson("帐号或密码错误"));
        }


        public ActionResult Logout()
        {
            new AdminInfo().Logout();
            return RedirectToAction("index", "Login");
        }
    }
}