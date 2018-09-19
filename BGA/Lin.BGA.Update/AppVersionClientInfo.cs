using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.Update
{
   public  class AppVersionClientInfo
    {
        public int ID { get; set; }
        public string Version { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Detail { get; set; }
        public string SRC { get; set; }
    }
}
