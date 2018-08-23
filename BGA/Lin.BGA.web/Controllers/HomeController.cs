using Lin.BGA.BLLFactory;
using Lin.BGA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lin.BGA.Model;
using System.Data.Entity;
using Tool;

namespace Lin.BGA.web.Controllers
{

    [AllowAnonymous]
    public class HomeController : BaseMPUnFilterController
    {
        // GET: MP/Home
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult menu()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult Note()
        {
           
            return View();
        }
        public ActionResult Top()
        {
            
            return View(CurrentUser);
        }


    }
}