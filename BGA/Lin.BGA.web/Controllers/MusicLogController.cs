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
//using System.Data.Entity;

namespace Lin.BGA.web.Controllers
{
    public class MusicLogController : BaseMPController
    {
        protected IMusicLogInfoService MusicLogBLL = AbstractFactory.CreateMusicLogInfoService();

        public ActionResult Index(int page = 1)
        {
            var list = MusicLogBLL.GetList(p => true);
            var Name = Function.GetRequestString("Name");
            var DateBegin = Function.GetRequestDateTime("DateBegin");
            var DateEnd = Function.GetRequestDateTime("DateEnd");
            if (!string.IsNullOrEmpty(Name))
            {
                list = list.Where(a => a.StoreInfo.Name.Contains(Name) || a.StoreInfo.Code.Contains(Name));
                ViewBag.TxtName = Name;
            }
            if (DateBegin > DicInfo.DateZone)
            {
                //list = list.Where(a => DbFunctions.DiffDays(a.CreateDate, DateBegin) <= 0);
                ViewBag.TxtDateBegin = DateBegin.ToString("yyyy-MM-dd");
            }
            if (DateEnd > DicInfo.DateZone)
            {
               // list = list.Where(a => DbFunctions.DiffDays(a.CreateDate, DateEnd) >= 0);
                ViewBag.TxtDateEnd = DateEnd.ToString("yyyy-MM-dd");
            }
            list = list.OrderByDescending(p => p.CreateDate);
            var result = list.ToPagedList(page, PageSize);
            return View(result);
        }


    }
}
