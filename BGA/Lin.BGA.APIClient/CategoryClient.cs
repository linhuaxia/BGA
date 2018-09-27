using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lin.BGA.Model;
using Tool;

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
            if (string.IsNullOrEmpty(TaskJson))
            {
                TaskJson = DocHelper.Read(GetLocalFileFullName());
            }
            else
            {
                DocHelper.Write(GetLocalFileFullName(), TaskJson);
            }
            var result = apiHelper.APIJsonDeserialize<IEnumerable<CategoryInfo>>(TaskJson);
            if (null==result||result.Count()==0)
            {
                return new List<CategoryInfo>();
            }
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
        private string GetLocalFileFullName()
        {
            return Environment.CurrentDirectory + "\\Category.json";
        }

        //public IEnumerable<CategoryInfo> GetListFromLocal()
        //{
        //    string TaskJson=  DocHelper.Read(GetLocalFileFullName());
        //    var result = apiHelper.APIJsonDeserialize<IEnumerable<CategoryInfo>>(TaskJson);
        //    if (null == result || result.Count() == 0)
        //    {
        //        return new List<CategoryInfo>();
        //    }
        //    foreach (var itemCategory in result)
        //    {
        //        foreach (var itemMusic in itemCategory.MusicInfo)
        //        {
        //            itemMusic.CategoryID = itemCategory.ID;
        //            itemMusic.CategoryInfo = itemCategory;
        //        }
        //    }
        //    return result;

        //}


    }
}
