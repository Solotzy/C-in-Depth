using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StartsWithEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            //延迟执行
            //Range方法并不会真的构造含有适当数字的列表
            //管道
            //用Select方法和匿名类型进程投影
            var collection = Enumerable.Range(0, 10)
                .Where(x => x%2 != 0)
                .Reverse()
                .Select(x => new {Original = x, SquareRoot = Math.Sqrt(x)});
            foreach (var element in collection)
            {
                Console.WriteLine("Sqrt({0})={1}",
                    element.Original,
                    element.SquareRoot);
            }
            Console.WriteLine();

            //排序不会改变原有集合，它返回的是新的序列
            var collection2 = Enumerable.Range(-5, 11)
                .Select(x => new {Original = x, Square = x*x})
                .OrderBy(x => x.Square)
                .ThenBy(x => x.Original);
            foreach (var element in collection2)
            {
                Console.WriteLine(element);
            }
            Console.Read();
        }
    }
}
