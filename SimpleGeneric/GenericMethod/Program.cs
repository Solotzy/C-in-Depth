using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethod
{
    class Program
    {
        static double TakeSquareRoot(int x)
        {
            return Math.Sqrt(x);
        }
        static void Main(string[] args)
        {
            List<int> integers = new List<int>
            {
                1,
                2,
                3,
                4
            };

            Converter<int, double> converter = TakeSquareRoot;
            List<double> doubles;
            doubles = integers.ConvertAll<double>(converter);
            foreach (var d in doubles)
            {
                Console.WriteLine(d);
            }

            Console.Read();
        }
    }
}
