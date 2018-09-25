using Lin.BGA.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.HDL
{
    public class StoreHelper
    {
        public StoreInfo GetLoginInfo()
        {
            string FileFullName = System.IO.Directory.GetCurrentDirectory() + "/登录信息";
            if (!File.Exists(FileFullName))
            {
                return null;
            }
            var JsonText = Tool.DocHelper.Read(FileFullName);
            var info = Newtonsoft.Json.JsonConvert.DeserializeObject<StoreInfo>(JsonText);
            return info;
        }
        public bool IsLoginFit()
        {
            string IP = System.Environment.MachineName;
            StoreInfo info = GetLoginInfo();
            if (null==info)
            {
                return false;
            }
            if (info.ID==0)
            {
                if (info.CreateDate<DateTime.Now)
                {
                    return false;
                }
            }

            return info.IP == IP;
        }
    }
}
