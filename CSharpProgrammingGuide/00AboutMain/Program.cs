using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00AboutMain
{
    /// <summary>
    /// Main可以在类和结构内声明
    /// </summary>
    struct Program
    {
        /// <summary>
        /// Main必须是静态，且不应该公开
        /// 返回类型有两种：void和int
        /// </summary>
        /// <param name="args">命令行实参</param>
        static void Main(string[] args)
        {
            //通过测试Length属性来确定参数是否存在
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a numeric argument");
            }
            Console.WriteLine("Hello");
            Console.ReadLine();
        }
    }
}
