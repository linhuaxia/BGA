using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tool;

namespace Lin.BGA.web.Models
{
    public class AdminInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public AdminInfo GetConst()
        {
            
            var JsonText = Tool.DocHelper.Read(HttpContext.Current.Server.MapPath("/Content/Json/Admin.json"));
            AdminInfo info = Newtonsoft.Json.JsonConvert.DeserializeObject<AdminInfo>(JsonText);
            return info;
        }
        public AdminInfo GetCurrent()
        {
            AdminInfo infoDB = GetConst();
            if (System.Web.HttpContext.Current.Session != null && System.Web.HttpContext.Current.Session["AdminInfo"] != null)
            {
                return (AdminInfo)System.Web.HttpContext.Current.Session["AdminInfo"];
            }
            string UserName = GetCurrentName();
            if (!string.IsNullOrEmpty(UserName))
            {
                if (UserName!= infoDB.Name)
                {
                    return null;
                }
                if (null != System.Web.HttpContext.Current.Session)
                {
                    System.Web.HttpContext.Current.Session["AdminInfo"] = infoDB;
                }

                return infoDB;
            }
            return null;
        }
        private string GetCurrentName()
        {
            string Md5ID = CookiesHelper.GetCookieValue("AdminCookies");
            if (string.IsNullOrEmpty(Md5ID))
            {
                return null;
            }
            Md5ID = Md5Helper.Md5Decrypt(Md5ID);
            int indexof = Md5ID.IndexOf("sharp_");
            if (indexof == 0)
            {
                Md5ID = Md5ID.Replace("sharp_", "");
            }
            return Md5ID;
        }
        public void Logout()
        {
            CookiesHelper.SetCookie("AdminCookies", "", DateTime.Now.AddDays(-111));
            System.Web.HttpContext.Current.Session.RemoveAll();

        }
        public void SetUserInfo(AdminInfo info,int RemberHour=24)
        {
            CookiesHelper.AddCookie("AdminCookies", Md5Helper.Md5Encrypt("sharp_" + info.Name), DateTime.Now.AddHours(RemberHour));
            System.Web.HttpContext.Current.Session["AdminInfo"] = info;
        }


    }
}