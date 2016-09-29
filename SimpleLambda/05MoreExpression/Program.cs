using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _05MoreExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<string, string, bool>> expression =
                (x, y) => x.StartsWith(y);
            var compiled1 = expression.Compile();

            Console.WriteLine(compiled1("First", "Second"));
            Console.WriteLine(compiled1("First", "Fir"));

            //构造方法调用的各个部件
            //方法的目标
            MethodInfo method = typeof(string).GetMethod
                ("StartsWith", new[] {typeof(string)});
            var target = Expression.Parameter(typeof(string), "x");
            var methodArg = Expression.Parameter(typeof(string), "y");
            Expression[] methodArgs = new[] {methodArg};

            //从以上部件创建CallExpression
            Expression call = Expression.Call(target, method, methodArgs);

            //将Call转换成Lambda表达式
            var lambdaPrameters = new[] {target, methodArg};
            var lambda = Expression.Lambda<Func<string, string, bool>>
                (call, lambdaPrameters);
            var compiled = lambda.Compile();
            Console.WriteLine(compiled("First","Second"));
            Console.WriteLine(compiled("First", "Fir"));

            Console.Read();


        }
    }
}
