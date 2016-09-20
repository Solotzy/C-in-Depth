using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09ReflectOfGeneric
{
    class Program
    {
        static void DemonstrateTypeof<X>()
        {
            //显示方法的类型参数
            Console.WriteLine(typeof(X));

            //显示泛型类型
            Console.WriteLine(typeof(List<>));
            Console.WriteLine(typeof(Dictionary<,>));

            //显示封闭类型(尽管使用了类型参数)
            Console.WriteLine(typeof(List<X>));
            Console.WriteLine(typeof(Dictionary<string, X>));

            //显示封闭类型
            Console.WriteLine(typeof(List<long>));
            Console.WriteLine(typeof(Dictionary<long, Guid>));
        }
        static void Main(string[] args)
        {
            DemonstrateTypeof<int>();
            Console.Read();
        }
    }
}
