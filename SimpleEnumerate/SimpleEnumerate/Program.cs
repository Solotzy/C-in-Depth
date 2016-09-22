/*
 * 迭代 C#1版本 大量代码
 */
using System;

namespace SimpleEnumerate
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] values = {"a", "b", "c", "d", "e"};
            IterationSample collection = new IterationSample(values,3);
            foreach (var x in collection)
            {
                Console.WriteLine(x);
            }
            Console.Read();
        }
    }
}
