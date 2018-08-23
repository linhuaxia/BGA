using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
           var result= new Lin.BGA.APIClient.CategoryClient().GetList();
           // Console.WriteLine(result);
           // Console.ReadLine();
        }
    }
}
