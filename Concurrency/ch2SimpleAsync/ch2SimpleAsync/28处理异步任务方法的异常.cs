/*
 * 问题
 *     对于任何设计来说，异常处理都是一个关键的部分
 * 
 * 解决方案
 *     可以用简单的try/catch来铺捕获异常，和同步代码使用的方法一样
 * 
 */

using System;
using System.Threading.Tasks;

namespace ch2SimpleAsync
{
    class _28处理异步任务方法的异常
    {
        static async Task ThrowExceptionAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            throw new InvalidOperationException("Test");
        }

        static async Task TestAsync()
        {
            //抛出异常并将存储在Task中
            Task task = ThrowExceptionAsync();
            try
            {
                //Task 对象呗await调用，异常在这里再次被引发
                await task;
            }
            catch (InvalidOperationException)
            {
                
                //这里，异常被正确地捕获
            }
        }
    }
}
