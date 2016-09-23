/*
 * 与try/finally一道工作的yield break
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace _05Finally
{
    class Program
    {
        static IEnumerable<int> CountWithTimeLimit(DateTime limit)
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (DateTime.Now >= limit)
                    {
                        yield break;
                    }
                    yield return i;
                }
            }
            finally
            {
                //不管循环是否结束都执行
                Console.WriteLine("Stopping!");
            }
        }
        static void Main(string[] args)
        {
            DateTime stop = DateTime.Now.AddSeconds(2);
            foreach (var i in CountWithTimeLimit(stop))
            {
                Console.WriteLine("Received {0}", i);
                if (i > 3)
                {
                    Console.WriteLine("Returning");
                    return;
                }
                Thread.Sleep(300);
            }

            //foreach (var i in CountWithTimeLimit(stop))
            //{
            //    Console.WriteLine("Received {0}", i);
            //    Thread.Sleep(300);
            //}
            Console.Read();
        }
    }
}
