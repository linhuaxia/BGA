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
    public class StoreController : Controller
    {
        // GET: API/Store
        public ActionResult Index()
        {
            return View();
        }


        protected IStoreInfoService StoreBLL = AbstractFactory.CreateStoreInfoService();
        //public JsonResult GetList()
        //{
        //    var result = StoreBLL.GetList(a => true).OrderByDescending(a => a.ID).Select(a => new {
        //        a.ID,
        //        a.Name,
        //        MusicInfo = a.MusicInfo.Where(m => m.Enable).OrderByDescending(m => m.SortID).ThenBy(m => m.ID).Select(m => new {
        //            m.ID,
        //            m.Name,
        //            m.PlayTime,
        //            m.SRC
        //        })
        //    });
        //    return Json(new APIJson(0, "", result),JsonRequestBehavior.AllowGet);
        //}
        public JsonResult Login(StoreInfo info)
        {
            var infoExist = StoreBLL.GetList(a => a.Code == info.Code).FirstOrDefault();
            if (null == infoExist)
            {
                return Json(new APIJson(-1, "帐户不存在"));
            }
            if (infoExist.Password != Tool.Md5Helper.Md5(info.Password))
            {
                return Json(new APIJson(-1, "密码错误"));
            }
            if (!string.IsNullOrEmpty(infoExist.IP) && info.IP != infoExist.IP)
            {
                return Json(new APIJson(-1, "系统检查登录设备异常，请联系管理员"));
            }
            infoExist.IP = info.IP;
            infoExist.CreateDate = DateTime.Now;
            StoreBLL.Edit(info);
            var result = new
            {
                infoExist.Name,
                infoExist.Code,
                infoExist.ID,
                infoExist.IP,
                infoExist.CreateDate
            };
            return Json(new APIJson(0, "登录成功", result));
        }
        public JsonResult GetStore(int ID)
        {
            var infoExist = StoreBLL.GetList(a => a.ID == ID).FirstOrDefault();
            if (null==infoExist)
            {
                return Json(new APIJson(-1, "店铺不存在", null), JsonRequestBehavior.AllowGet);
            }
            var result = new
            {
                infoExist.ID,
                infoExist.Name,
                infoExist.Code,
                infoExist.Password,
                infoExist.IP,
                infoExist.CreateDate
            };
            return Json(new APIJson(0, "", result), JsonRequestBehavior.AllowGet);
        }
    }
}