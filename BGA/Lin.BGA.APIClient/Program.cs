﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.APIClient
{
    class Program
    {
        static void Main(string[] args)
        {
           var result= new CategoryClient().GetList();
           // Console.WriteLine(result);
           // Console.ReadLine();
        }
    }
}
