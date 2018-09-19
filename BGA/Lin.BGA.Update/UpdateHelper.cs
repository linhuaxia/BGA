using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.Update
{
    public class UpdateHelper
    {
        public AppVersionClientInfo GetLast()
        {
            APIHellper apiHelper = new APIHellper();
            string URL = "AppVersion/GetLast";
            URL = APIHellper.GetAPI(URL, string.Empty);
            string TaskJson = apiHelper.GetHttpData(URL);
            var result = apiHelper.APIJsonDeserialize<AppVersionClientInfo>(TaskJson);
            return result;
        }
        public bool DownLoad(string SRC, string SaveFileFullName,
            System.Net.DownloadProgressChangedEventHandler client_DownloadProgressChanged,
            AsyncCompletedEventHandler client_DownloadFileCompleted)
        {
            SRC = APIHellper.ConstConfig.APIURL + SRC;

            APIHellper apiHelper = new APIHellper();
            apiHelper.DownloadFileAsync(SRC, SaveFileFullName, client_DownloadProgressChanged, client_DownloadFileCompleted);
            return true;

        }

    }
}
