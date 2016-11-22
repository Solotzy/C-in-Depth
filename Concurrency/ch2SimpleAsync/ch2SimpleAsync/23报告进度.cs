/*
 * 问题
 *     异步操作执行的过程中，需要展示操作的进度
 * 
 * 解决方案
 *     使用IProgress<T>和Progress<T>类型，编写的async方法需要有IProgress<T>参数，
 *     其中T是需要报告的进度类型
 * 
 */

using System;
using System.Threading.Tasks;

namespace ch2SimpleAsync
{
    class _23报告进度
    {
        //调用报告进度
        static async Task CallMyMethodAsync()
        {
            var progress = new Progress<double>();
            progress.ProgressChanged += (sender, args) =>
            {
                Console.WriteLine(args);
            };
            await MyMethodAsync(progress);
        }

        static async Task MyMethodAsync(IProgress<double> progress = null)
        {
            bool done = false;
            double percentComplete = 0;
            while (!done)
            {
                if(progress != null)
                    progress.Report(percentComplete);
            }
        }
    }
}
