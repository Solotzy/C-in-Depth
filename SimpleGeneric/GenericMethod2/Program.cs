using System;
using System.Collections.Generic;
using System.Linq;
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
            List<string> list = MakeList<string>("Line1", "Line2");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
}
