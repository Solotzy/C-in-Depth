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

            //可空类型的装箱和拆箱行为
            Console.WriteLine("\n可空类型的装箱和拆箱行为");
            Nullable<int> nullable = 5;
            //装箱成 有值的可空类型的实例
            object boxed = nullable;
            Console.WriteLine(boxed.GetType());

            //拆箱成非可空变量
            int normal = (int) boxed;
            Console.WriteLine(normal);

            //拆箱成可空变量
            nullable = (Nullable<int>) boxed;
            Console.WriteLine(nullable);

            nullable = new Nullable<int>();
            //装箱成 没有值的可空类型的实例
            boxed = nullable;
            Console.WriteLine(boxed == null);

            //拆箱成可空变量
            nullable = (Nullable<int>) boxed;
            Console.WriteLine(nullable.HasValue);

            normal = (int)boxed;
            Console.WriteLine(normal);

            Console.Read();
        }
    }
}
