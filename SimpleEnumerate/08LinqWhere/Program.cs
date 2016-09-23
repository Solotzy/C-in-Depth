/*
 * 使用迭代器块实现LINQ的Where方法
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08LinqWhere
{
    class Program
    {
        //我们将实现分为两部分：参数验证和真正的过滤逻辑
        //参数验证
        public static IEnumerable<T> Where<T>(IEnumerable<T> source,
            Predicate<T> predicate)
        {
            //热情地检查参数
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }
            //懒惰地处理数据
            return WhereImpl(source, predicate);
        }

        //过滤逻辑
        private static IEnumerable<T> WhereImpl<T>(IEnumerable<T> source,
            Predicate<T> predicate)
        {
            foreach (T item in source)
            {
                //检查当前项与谓词是否匹配
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        static void Main(string[] args)
        {
            IEnumerable<string> lines = _07IterationText.Program.ReadLines("../../Program.cs");
            Predicate<string> predicate = delegate(string line)
            {
                return line.StartsWith("using");
            };
            foreach (var line in Where(lines, predicate))
            {
                Console.WriteLine(line);
            }
            Console.Read();
        }
    }
}
