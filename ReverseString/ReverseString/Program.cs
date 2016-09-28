using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "I am a girl!";
            //先反转所有的字符串
            str = Reverse(str);
            //存储结果
            var result = "";
            //对其中的每个单词进行反转
            //以空格分割单词
            foreach (var s in str.Split(' '))
            {
                //反转单词
                result += Reverse(s);
                //添加分隔符
                result += " ";
            }
            //去掉多余的空格时
            var trimEnd = result.TrimEnd();
            Console.WriteLine(trimEnd);
            Console.Read();

        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        static string Reverse(string original)
        {
            var arr = original.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
