using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.APIClient
{
    public class BaseAPIClient
    {
        public BaseAPIClient()
        {
            APIAccessToken = string.Empty;
        }

        public string APIAccessToken { get; set; }
    }
}
