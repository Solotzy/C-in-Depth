/*
 * 问题
 *     在并行操作结束时，需要聚合结果，包括累加和、平均值等
 * 
 * 解决方案
 *     Parallel类通过局部值(local value)的概念来实现聚合，局部值就是只在
 *     并行循环内部存在的变量。这意味着循环体中的代码可以直接访问值，不需要担心同步问题。
 *     循环中的代码使用LocalFinally委托来对每个局部值进行聚合。
 *     需要注意的是，localFinally委托需要以同步的方式对存放结果的变量进行访问。
 * 
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ch3SimpleTPL
{
    class _32并行聚合
    {
        // 并行求累加和的例子
        // 注意，这不是最高效的实现方式
        // 只是举个例子，说明用锁来保护共享状态
        static int ParallelSum(IEnumerable<int> values)
        {
            object mutex = new object();
            int result = 0;
            Parallel.ForEach(source: values,
                localInit: () => 0,
                body: (item, state, localValue) => localValue + item,
                localFinally: localValue =>
                {
                    lock (mutex)
                    {
                        result += localValue;
                    }
                });
            return result;
        }

        //并行LINQ对聚合的支持，比Parallel类更加顺手
        static int ParallelSumLinq(IEnumerable<int> values)
        {
            return values.AsParallel().Sum();
        }

        //PLINQ也可通过Aggregate实现通用的聚合功能
        static int ParallelSumPLinq(IEnumerable<int> values)
        {
            return values.AsParallel().Aggregate(
                seed: 0,
                func: (sum, item) => sum + item
                );
        }
    }
}
