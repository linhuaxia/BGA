using Lin.BGA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.IBLL
{
    public partial interface IMusicLogInfoService : IBaseService<MusicLogInfo>
    {
        bool Create(IEnumerable<MusicLogInfo> list);


    }
}
