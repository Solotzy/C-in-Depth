using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06NewAboutTypeInference
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput">输入值类型</typeparam>
        /// <typeparam name="TOutput">输出值类型</typeparam>
        /// <param name="input">输入值</param>
        /// <param name="converter">委托 负责转换类型</param>
        static void PrintConvertedValue<TInput, TOutput>
            (TInput input, Converter<TInput, TOutput> converter)
        {
            Console.WriteLine(converter(input));
        }

        delegate T MyFunc<T>();
        //根据一天当中的时间来选择返回int或object
        static void WriteResult<T>(MyFunc<T> function)
        {
            Console.WriteLine(function());
        }

        static void Main(string[] args)
        {
            //1.
            PrintConvertedValue("I'm a string", x => x.Length);

            //2.
            WriteResult(delegate
            {
                if (DateTime.Now.Hour < 12)
                {
                    return 10;
                }
                else
                {
                    return new object();
                }
            });

            Console.Read();
        }
    }
}
