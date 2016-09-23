/*
 * 迭代时刻表中的日期
 */
using System;
using System.Collections.Generic;

namespace _06IterationDateTime
{
    class Program
    {
        public DateTime StartDate = DateTime.Now;
        public DateTime EndDate = DateTime.Now.AddDays(5);
        public IEnumerable<DateTime> DateRange
        {
            get
            {
                for (DateTime day = StartDate;
                    day <= EndDate;
                    day = day.AddDays(1))
                {
                    yield return day;
                }
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            foreach (var dateTime in p.DateRange)
            {
                Console.WriteLine(dateTime.Day);
            }
            Console.Read();
        }
    }
}
