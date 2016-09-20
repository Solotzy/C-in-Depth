using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethod2
{
    class Program
    {
        static List<T> MakeList<T>(T first, T second)
        {
            return new List<T>
            {
                first,
                second
            };
        }
        static void Main(string[] args)
        {
            //List<string> list = MakeList<string>("Line1", "Line2");
            //Type argument specification is redundant
            //类型参数规格是多余的 因为C#2 编辑器类型推断出来了
            //注意 类型推断只适用于泛型方法，不适用于泛型类型
            List<string> list = MakeList("Line1", "Line2");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
}
