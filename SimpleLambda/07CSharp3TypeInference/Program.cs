using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07CSharp3TypeInference
{
    class Program
    {
        static void PrintType<T>(T first, T second)
        {
            Console.WriteLine(typeof(T));
        }

        static void ConvertTwice<TInput, TMiddle, TOutput>
            (TInput input,
                Converter<TInput, TMiddle> firstConversion,
                Converter<TMiddle, TOutput> secondConversion)
        {
            TMiddle middle = firstConversion(input);
            TOutput output = secondConversion(middle);
            Console.WriteLine(output);
        }
        static void Main(string[] args)
        {
            //1.
            PrintType(1, new object());

            //2.
            //类型推断现在分阶段进行
            ConvertTwice("Another string",
                         text => text.Length,
                         length => Math.Sqrt(length));

            Console.Read();
        }
    }
}
