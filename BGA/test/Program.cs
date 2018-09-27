using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Lin.BGA.APIClient.CategoryClient c = new Lin.BGA.APIClient.CategoryClient();
            c.GetList();
            bool online = false; //是否在线
            Ping ping = new Ping();
            PingReply pingReply = ping.Send("bga.web.gzlfxx.cn");
            if (pingReply.Status == IPStatus.Success)
            {
                online = true;
                Console.WriteLine("当前在线，已ping通！");
            }
            else
            {
                Console.WriteLine("不在线，ping不通！");
            }
            Console.ReadLine();

        }
    }
}
