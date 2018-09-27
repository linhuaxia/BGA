using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class AsyncHelper
    {
        public static Task<TResult> Run<TResult>(Func<TResult> func)
        {
            return Task.Factory.StartNew<TResult>(func);
        }
    }

}
