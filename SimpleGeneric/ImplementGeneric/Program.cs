using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementGeneric
{
    class Program
    {
        //默认值表达式 default(T)
        static int CompareToDefault<T>(T value)
            where T : IComparable<T>
        {
            return value.CompareTo(default(T));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CompareToDefault("x"));
            Console.WriteLine(CompareToDefault(10));
            Console.WriteLine(CompareToDefault(0));
            Console.WriteLine(CompareToDefault(-10));
            Console.WriteLine(CompareToDefault(DateTime.MinValue));
            Console.Read();
        }
    }
}
