/*
 * 将匿名方法用于Action<T>委托类型
 */
using System;
using System.Collections.Generic;


namespace _04Action1
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用匿名方法创建Action<string>
            Action<string> printReverse = delegate(string text)
            {
                char[] chars = text.ToCharArray();
                Array.Reverse(chars);
                Console.WriteLine(new string(chars));
            };
            Action<int> printRoot = delegate(int number)
            {
                Console.WriteLine(Math.Sqrt(number));
            };
            Action<IList<double>> printMean = delegate(IList<double> numbers)
            {
                double total = 0;
                //在匿名方法中使用循环
                foreach (double value in numbers)
                {
                    total += value;
                }
                Console.WriteLine(total/numbers.Count);
            };

            //和调用普通方法一样调用委托
            printReverse("Hello world");
            printRoot(2);
            printMean(new double[] {1.5, 2.5, 3, 4.5});
            Console.Read();
        }
    }
}
