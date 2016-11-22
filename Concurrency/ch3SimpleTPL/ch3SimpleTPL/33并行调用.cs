/*
 * 问题
 *     需要并行调用一批方法，并且这些方法(大部分)是互相独立的。
 * 
 * 解决方案
 *     Parallel类有一个简单的成员Invoke，就可用于这种场合
 * 
 */

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ch3SimpleTPL
{
    class _33并行调用
    {
        //将一个数组分为两半，并且分别独立处理
        static void ProcessArray(double[] array)
        {
            Parallel.Invoke(
                () => ProcessPartialArray(array, 0, array.Length/2),
                () => ProcessPartialArray(array, array.Length/2, array.Length)
                );
        }

        static void ProcessPartialArray(double[] array, int begin, int end)
        {
            // 计算密集型的处理过程
        }

        // 如果在运行之前都无法确定调用的数量，就可以在Parallel.Invoke函数中输入一个委托数组
        static void DoAction20Times(Action action)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray();
            Parallel.Invoke(actions);
        }

        //支持取消操作
        static void DoAction20Times(Action action, CancellationToken token)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray();
            Parallel.Invoke(new ParallelOptions {CancellationToken = token}, actions);
        }
    }
}
