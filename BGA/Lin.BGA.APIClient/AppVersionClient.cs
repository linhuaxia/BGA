using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lin.BGA.Model;

namespace Lin.BGA.APIClient
{
    public  class AppVersionClient : BaseAPIClient
    {
        private static APIHellper apiHelper = new APIHellper();


        public AppVersionClient()
        {
            
        }


        public AppVersionInfo GetLast()
        {
            APIHellper apiHelper = new APIHellper();
            string URL = "AppVersion/GetLast";
            URL = APIHellper.GetAPI(URL, string.Empty);
            string TaskJson = apiHelper.GetHttpData(URL);
            var result = apiHelper.APIJsonDeserialize<AppVersionInfo>(TaskJson);
            return result;
        }



    }
}
