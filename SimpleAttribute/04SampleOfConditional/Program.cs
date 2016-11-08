using System.Diagnostics;

namespace _04SampleOfConditional
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        /// <summary>
        /// 通常用于在DEBUG标识符启用跟踪，并记录的功能的调试版本，但不在发布版本中
        /// 一个条件方法必须是类或结构声明的方法，而且不能有返回值
        /// </summary>
        [Conditional("DEBUG")]
        static void DebugMethod()
        {
            
        }
    }
}
