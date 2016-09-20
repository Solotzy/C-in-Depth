using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _11GetMethodOfGeneric
{
    class Program
    {
        public static void PrintTypeParameter<T>()
        {
            Console.WriteLine(typeof(T));
        }
        static void Main(string[] args)
        {
            Type type = typeof(Program);
            MethodInfo definition = type.GetMethod("PrintTypeParameter");
            MethodInfo constructed = definition.MakeGenericMethod(typeof(string));
            constructed.Invoke(null, null);
            Console.Read();
        }
    }
}
