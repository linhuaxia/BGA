﻿using Lin.BGA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.DALFactory
{
    /// <summary>
    /// 抽象工厂，通过反射创建类的实例
    /// </summary>
    public partial class AbstractFactory
    {
        private static readonly string AssemblyPath = ConfigurationSettings.AppSettings["DALAssemblyPath"];
        private static readonly string AssemblyNameSpace = ConfigurationSettings.AppSettings["DALAssemblyNameSpace"];

        private static object CreateInstance(string ClassName)
        {
            var assembly = Assembly.Load(AssemblyPath);
            return assembly.CreateInstance(ClassName);
        }
    }
}
