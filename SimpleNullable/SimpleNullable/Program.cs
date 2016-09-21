using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNullable
{
    class Program
    {
        static void Display(Nullable<int> x)
        {
            Console.WriteLine("HasValue: {0}", x.HasValue);
            if (x.HasValue)
            {
                Console.WriteLine("Value: {0}", x.Value);
                Console.WriteLine("Explicit conversion: {0}", (int)x);
            }
            Console.WriteLine("GetValueOrDefault(): {0}",
                x.GetValueOrDefault());
            Console.WriteLine("GetValueOrDeafult(10): {0}",
                x.GetValueOrDefault(10));
            Console.WriteLine("ToString(): \"{0}\"", x.ToString());
            Console.WriteLine("GetHashCode(): {0}", x.GetHashCode());
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Nullable<int> x = 5;
            //包装等于5的值
            x = new Nullable<int>(5);
            Console.WriteLine("Instance with value:");
            Display(x);

            //构造没有值的实例
            x = new Nullable<int>();
            Console.WriteLine("Instance without value:");
            Display(x);
            Console.Read();
        }
    }
}
