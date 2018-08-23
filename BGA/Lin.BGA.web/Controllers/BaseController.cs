using Lin.BGA.IBLL;
using Lin.BGA.Model;
using Lin.BGA.BLLFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lin.BGA.web.Models;

namespace Lin.BGA.web.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {
        }
        public AdminInfo CurrentUser;


        public const int PageSize = 20;  //每页记录数
        protected int TheCount = 0;     //记录总数

        protected IProfilesInfoService ProfilesBLL = AbstractFactory.CreateProfilesInfoService();
        protected IAppVersionInfoService AppVersionBLL = AbstractFactory.CreateAppVersionInfoService();
        protected ICategoryInfoService CategoryBLL = AbstractFactory.CreateCategoryInfoService();
        protected IMusicInfoService MusicBLL = AbstractFactory.CreateMusicInfoService();
        protected IStoreInfoService StoreBLL = AbstractFactory.CreateStoreInfoService();



    }
}