using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08LinqWhere
{
    class Program
    {
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
