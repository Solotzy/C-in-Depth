/*
 * 进程：是一个具有一定独立功能的程序关于某个数据集合的一次获取。
 *       它是操作系统动态执行的基本单元，在传统的操作系统中，进程
 *       既是基本的分配单元，也是基本的执行单元
 * 线程：是“进程”中某一单一顺序的控制流
 */
using System.Diagnostics;

namespace _01ProcessAndThread
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region 获取进程
        public Process[] GetProcess(string ip = "")
        {
            if (string.IsNullOrEmpty(ip))
                return Process.GetProcesses();
            return Process.GetProcesses(ip);
        }
        #endregion
    }


}
