using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimpleLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList {"First", "Second", "Third"};
            //Cast通过把每个元素都转换为目标类型(遇到不少正确类型的任何元素的时候，就会出错)来处理
            IEnumerable<string> strings = list.Cast<string>();
            foreach (string item in strings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            list = new ArrayList {1, "not an int", 2, 3};
            //OfType首先进行一个测试，以跳过任何具有错误类型的元素。
            IEnumerable<int> ints = list.OfType<int>();
            foreach (int item in ints)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}
