using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Join
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 内连接
             * 
             * 查询选择左边的序列
             * join right-range-variable in right-sequence
             *     on left-key-selector equals right-key-selector
             *  
             * 1.根据项目把缺陷和通知订阅连接在一起
             * var query = from defect in SampleData.AllDefects
             *             join subscription in SampleData.AllSubscriptions
             *                 on defect.Project equals subscription.Project
             *             select new { defect.Summary, subscription.EmailAddress };
             * foreach(var entry in query)
             * {
             *     Console.WriteLine("{0}: {1}", entry.EmailAddress, entry.Summary);
             * }
             * 
             * 
             */
        }
    }
}
