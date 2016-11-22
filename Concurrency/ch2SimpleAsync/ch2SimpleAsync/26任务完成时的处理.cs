/*
 * 问题
 *     正在await一批任务，希望在每个任务完成时对它做一些处理，
 *     另外，希望在任务一完成就立即进行处理，而不需要等待其他任务
 *
 *  解决方案
 *      最简单的方案是通过引入更高级的async方法来await任务，并对结果进行处理，
 *      从而重新构建代码，提取出处理过程后，代码就明显简化了
 * 
 */

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ch2SimpleAsync
{
    class _26任务完成时的处理
    {
        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }

        //static async Task AwaitAndProcessAsync(Task<int> task)
        //{
        //    var result = await task;
        //    Trace.WriteLine(result);
        //}

        //这个方法输出 1 2 3
        public static async Task ProcessTasksAsync()
        {
            //创建任务队列 taskC是最先完成的 因为时间
            Task<int> taskA = DelayAndReturnAsync(2);
            Task<int> taskB = DelayAndReturnAsync(3);
            Task<int> taskC = DelayAndReturnAsync(1);
            var tasks = new[] {taskA, taskB, taskC};

            var processingTasks = tasks.Select(async t =>
            {
                var result = await t;
                Trace.WriteLine(result);
            }).ToArray();

            //等待全部处理过程的完成
            await Task.WhenAll(processingTasks);
        }
    }
}
