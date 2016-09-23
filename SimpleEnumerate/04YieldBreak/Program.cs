using System;
using System.Collections.Generic;
using System.Threading;

namespace _04YieldBreak
{
    class Program
    {
        static IEnumerable<int> CountWithTimeLimit(DateTime limit)
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
        static void Main(string[] args)
        {
            DateTime stop = DateTime.Now.AddSeconds(2);
            foreach (var i in CountWithTimeLimit(stop))
            {
                Console.WriteLine("Received {0}", i);
                Thread.Sleep(300);
            }
            Console.Read();
        }
    }
}
