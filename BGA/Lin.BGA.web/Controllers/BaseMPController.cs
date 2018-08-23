using Lin.BGA.BLLFactory;
using Lin.BGA.IBLL;
using Lin.BGA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lin.BGA.web.Controllers 
{
    [MPAuthorize]
    public class BaseMPController : BaseMPUnFilterController
    {
        public BaseMPController()
        {
            //ViewBag.PowerActionBLL = PowerActionBLL;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (null == CurrentUser)
            {
                filterContext.Result = RedirectToAction("index", "Login",new { area= "MP"});
                return;
            }
            ViewBag.CurrentUser = CurrentUser;
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            
        }

    }

    public class BaseMPUnFilterController : BaseController
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            CurrentUser = new Models.AdminInfo().GetCurrent();
            if (null == CurrentUser)
            {
                
                filterContext.Result = RedirectToAction("index", "Login");
                return;
            }

        }
    }

    public class MPAuthorizeAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var CurrentUser = new Models.AdminInfo().GetCurrent();
            return null != CurrentUser;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var result = new APIJson(-502, "Oauth deny");
                filterContext.Result = new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}