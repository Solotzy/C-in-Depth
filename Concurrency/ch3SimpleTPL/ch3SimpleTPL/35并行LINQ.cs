/*
 * 问题
 *     需要对一批数据进行并行处理，生成另外一批数据，或者对数据进行统计
 *  
 * 解决方案
 *     并行LINQ(PLINQ)扩展了LINQ，以支持并行处理
 *     
 *     PLINQ非常适用于数据流的操作，一个数据队列作为输入，一个数据队列作为输出。
 * 
 */

using System.Collections.Generic;
using System.Linq;

namespace ch3SimpleTPL
{
    class _35并行LINQ
    {
        //将序列中的每个元素都乘以2
        static IEnumerable<int> MultiplyBy2(IEnumerable<int> values)
        {
            return values.AsParallel().Select(item => item*2);
        }

        //指明要求保持原来的次序
        static IEnumerable<int> MultiplyBy2Order(IEnumerable<int> values)
        {
            return values.AsParallel().AsOrdered().Select(item => item*2);
        }

        //并行LINQ的另一个常规用途是用并行方式对数据进行聚合或汇总
        //并行的累加求和
        static int ParallelSum(IEnumerable<int> values)
        {
            return values.AsParallel().Sum();
        }
    }
}
