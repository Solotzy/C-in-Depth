using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ExplicitCast
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList {"First", "Second", "Third"};
            var strings = from string entry in list
                select entry.Substring(0, 3);
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            //2.
            var newlist = list.Cast<string>().Select(entry => entry.Substring(0, 3));
            newlist.ToList().ForEach(Console.WriteLine);
            Console.Read();
        }
    }
}
