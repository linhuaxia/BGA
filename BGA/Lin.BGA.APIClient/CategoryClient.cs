using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lin.BGA.Model;

namespace Lin.BGA.APIClient
{
    public  class CategoryClient : BaseAPIClient
    {
        private static APIHellper apiHelper = new APIHellper();


        public CategoryClient()
        {
            
        }


        public  IEnumerable<CategoryInfo> GetList()
        {
            string URL = "Category/GetList";

            URL = APIHellper.GetAPI(URL, APIAccessToken);
            string TaskJson =  apiHelper.GetHttpData(URL);

            var result = apiHelper.APIJsonDeserialize<IEnumerable<CategoryInfo>>(TaskJson);
            foreach (var itemCategory in result)
            {
                foreach (var itemMusic in itemCategory.MusicInfo)
                {
                    itemMusic.CategoryID = itemCategory.ID;
                    itemMusic.CategoryInfo = itemCategory;
                }
            }
            return result;
        }



    }
}
