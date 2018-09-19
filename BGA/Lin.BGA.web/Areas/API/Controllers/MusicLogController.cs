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
    public class MusicLogController : Controller
    {

        protected IMusicLogInfoService MusicLogBLL = AbstractFactory.CreateMusicLogInfoService();
        protected IStoreInfoService StoreBLL = AbstractFactory.CreateStoreInfoService();
        public JsonResult Create(IEnumerable<MusicLogInfo> list)
        {
            if (list.Count()==0)
            {
                return Json(new APIJson(0, "",true), JsonRequestBehavior.AllowGet);
            }
            int StoreID = list.First().StoreID;
            if (null== StoreBLL.GetList(a => a.ID == StoreID).FirstOrDefault())
            {
                return Json(new APIJson(0, "店铺帐户已不存在",false), JsonRequestBehavior.AllowGet);
            }
            foreach (var item in list)
            {
                if (null==item.MusicName)
                {
                    item.MusicName = string.Empty;
                }
                if (null==item.CategoryName)
                {
                    item.CategoryName = string.Empty;
                }
                
            }
            bool result= MusicLogBLL.Create(list);

            return Json(new APIJson(0, "", result),JsonRequestBehavior.AllowGet);
        }

    }
}