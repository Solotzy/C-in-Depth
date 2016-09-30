using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06JoinInto
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 使用join...into子句进行分组连接
             * var query = from defect in SampleData.AllDefects
             *             join subscription in SampleData.AllSubscriptions
             *                 on defect.Project equals subscription.Project
             *                 into groupedSubscriptions
             *             select new { Defect = defect,
             *                          Subscriptions = groupedSubscriptions };
             * foreach(var entry in query)
             * {
             *     Console.WriteLine(entry.Defect.Summary);
             *     foreach(var subscription in entry.Subscriptrions)
             *     {
             *         Console.WriteLine(" {0}", subscription.EmailAddress);
             *     }
             * }
             * 
             * 
             * 
             */
        }
    }
}
