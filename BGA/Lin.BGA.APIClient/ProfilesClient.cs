using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lin.BGA.Model;

namespace Lin.BGA.APIClient
{
    public  class ProfilesClient : BaseAPIClient
    {
        private static APIHellper apiHelper = new APIHellper();


        public ProfilesClient()
        {
            
        }


        public ProfilesSettingInfo GetAllConfig()
        {
            string URL = "Profiles/GetAllConfig";

            URL = APIHellper.GetAPI(URL, APIAccessToken);
            string TaskJson =  apiHelper.GetHttpData(URL);

            var result = apiHelper.APIJsonDeserialize<ProfilesSettingInfo>(TaskJson);
            
            return result;
        }

        public class ProfilesSettingInfo
        {
            public int EnableUpdateTimeBegin { get; set; }
            public int EnableUpdateTimeEnd { get; set; }
            public int EnableUpdateTimeInterval { get; set; }
        }


    }
}
