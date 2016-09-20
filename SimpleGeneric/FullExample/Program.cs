using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Pair<int, string> pa = new Pair<int, string>(10, "value");
            Pair<int, string> pair = Pair.Of(10, "value");
        }
    }
}
