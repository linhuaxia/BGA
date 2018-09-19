using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lin.BGA.Model;
using Lin.BGA.IDAL;
using Lin.BGA.IBLL;
using Tool;

namespace Lin.BGA.BLL
{
    public partial class MusicLogInfoService : BaseService<MusicLogInfo>, IMusicLogInfoService
    {

        public bool Create(IEnumerable<MusicLogInfo> list)
        {
            foreach (var item in list)
            {
                CurrentDAL.Create(item);
            }
            try
            {
                CurrentDBSession.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
 