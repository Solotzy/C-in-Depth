using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //匿名方法
            Func<string, int> returnLength;
            returnLength = delegate(string text)
            {
                return text.Length;
            };
            Console.WriteLine(returnLength("Hello"));

            //Lambda表达式
            Func<string, int> returnLengthLam;
            returnLengthLam = (string text) => { return text.Length; };
            Console.WriteLine(returnLengthLam("World!"));

            //简化Lambda表达式 用单一表达式作为主体
            returnLengthLam = (string text) => text.Length;
            Console.WriteLine(returnLengthLam("World!"));

            //简化Lambda表达式 隐式类型的参数列表
            returnLengthLam = (text) => text.Length;
            Console.WriteLine(returnLengthLam("World!"));

            //简化Lambda表达式 单一参数的快捷语法
            returnLengthLam = text => text.Length;
            Console.WriteLine(returnLengthLam("World!"));

            Console.Read();
        }
    }
}
