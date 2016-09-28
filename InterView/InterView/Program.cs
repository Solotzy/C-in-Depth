using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView
{
    class A
    {
        public static int X = 2;

        static A()
        {
            X = B.Y + 1;
        }
    }

    class B
    {
        public static int Y = A.X + 1;

        public static void Main(string[] args)
        {
            Console.WriteLine("A.X={0},B.Y={1}", A.X, B.Y);
            Console.Read();
        }
    }
}
