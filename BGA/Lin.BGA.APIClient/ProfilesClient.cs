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


        public List<ProfilesInfo> GetAllConfig()
        {
            string URL = "Profiles/GetAllConfig";

            URL = APIHellper.GetAPI(URL, APIAccessToken);
            string TaskJson =  apiHelper.GetHttpData(URL);

            var result = apiHelper.APIJsonDeserialize<List<ProfilesInfo>>(TaskJson);
            
            return result;
        }



    }
}
