using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Let
{
    class Program
    {
        static void Main(string[] args)
        {
            /* let 标识符 = 表达式
             * 
             * 1.在不使用let子句的情况下，按用户名称的长度来排序
             * var query = form user in SampleData.AllUsers
             *             orderBy user.Name.Length
             *             select user,Name;
             * foreach(var name in query)
             * {
             *     Console.WriteLine("{0}: {1}", name.Length, name);
             * }
             * 调用了Length属性两次，一个是对用户进行排序，一次用于显示
             * 
             * 2.使用let子句来消除冗余的计算
             * var query = from user in SampleData.AllUsers
             *             let length = user.Name.Length
             *             orderby length
             *             select new { Name = user.Name, Length = length };
             * foreach(var entry in query)
             * {
             *     Console.WriteLine("{0}: {1}", entry.Length, entry.Name);
             * }
             * 
             */
        }
    }
}
