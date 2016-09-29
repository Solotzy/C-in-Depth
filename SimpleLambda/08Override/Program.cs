using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08Override
{
    class Program
    {
        static void Execute(Func<int> action)
        {
            Console.WriteLine("action returns an int:" + action());
        }

        static void Execute(Func<double> action)
        {
            Console.WriteLine("action returns a double:" + action());
        }
        static void Main(string[] args)
        {
            //C#2会编译错误
            //C#3会选择更好的
            //怎么更好 int到int int到double
            Execute(() => 1);
            Console.Read();
        }
    }
}
