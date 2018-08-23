using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lin.BGA.Model;
using Newtonsoft.Json;
using static Lin.BGA.APIClient.APIHellper;

namespace Lin.BGA.APIClient
{
    public class StoreClient : BaseAPIClient
    {
        private static APIHellper apiHelper = new APIHellper();


        public StoreClient()
        {

        }

        public  StoreInfo Login(StoreInfo info,out string Msg)
        {
            string URL = "Store/Login";
            URL = APIHellper.GetAPI(URL, APIAccessToken);
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(info);
            string TaskJson = apiHelper.PostHttpData(URL, postData);
            var obj = JsonConvert.DeserializeObject<ClientAPIJSON<StoreInfo>>(TaskJson);
            Msg = obj.ErrorMsg;
            return obj.Data;
        }
        public StoreInfo GetStore(int ID)
        {
            string URL = "Store/GetStore/"+ID;

            URL = APIHellper.GetAPI(URL, APIAccessToken);
            string TaskJson = apiHelper.GetHttpData(URL);

            var result = apiHelper.APIJsonDeserialize<StoreInfo>(TaskJson);
           
            return result;

        }



    }
}
