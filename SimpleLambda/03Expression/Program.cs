using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _03Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            //一个非常简单的表达式树，2和3相加
            Expression firstArg = Expression.Constant(2);
            Expression secondArg = Expression.Constant(3);
            Expression add = Expression.Add(firstArg, secondArg);

            Console.WriteLine(add);

            //编译并执行一个表达式树
            Func<int> compiled = Expression.Lambda<Func<int>>(add).Compile();
            Console.WriteLine(compiled());

            //用Lambda表达式创建表达式树
            Expression<Func<int>> return5 = () => 5;
            Func<int> compiled2 = return5.Compile();
            Console.WriteLine(compiled2());

            Console.Read();
        }
    }
}
