using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lin.BGA.Model;

namespace Lin.BGA.APIClient
{
    public class MusicLogClient : BaseAPIClient
    {
        private static APIHellper apiHelper = new APIHellper();


        public MusicLogClient()
        {

        }

        public bool CreateToClient(MusicLogInfo info)
        {
            List<MusicLogInfo> list = GetClient();
            if (null == list)
            {
                list = new List<MusicLogInfo>();
            }
            if (null == info.CreateDate)
            {
                info.CreateDate = DateTime.Now;
            }
            list.Add(info);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return Tool.DocHelper.Write(GetLogFileFullName(), json);
        }
        private string GetLogFileFullName()
        {
            return Environment.CurrentDirectory + "\\MusicLog.json";
        }
        private List<MusicLogInfo> GetClient()
        {
            string json = Tool.DocHelper.Read(GetLogFileFullName());
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MusicLogInfo>>(json);
        }

        public bool CreateToServer()
        {
            Task.Run<bool>(() => {
                string json = Tool.DocHelper.Read(GetLogFileFullName());
                APIHellper apiHelper = new APIHellper();
                string URL = "MusicLog/Create";
                URL = APIHellper.GetAPI(URL, string.Empty);
                string TaskJson = apiHelper.PostHttpData(URL, json);
                var result = apiHelper.APIJsonDeserialize<bool>(TaskJson);
                return result;
            });
            return true;
        }



    }
}
