/*
 * 问题
 *     有一批数据，需要对每个元素进行相同的操作。
 *     该操作是计算密集型的，需要耗费一定的时间。
 * 
 * 解决方案
 *     Parallel类型有专门为此设计的ForEach方法
 * 
 */

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ch3SimpleTPL
{
    class _31数据的并行处理
    {
        //使用一批矩阵，对每一个矩阵都进行旋转
        void RotateMatrices(IEnumerable<Matrix> matrices, float degrees)
        {
            Parallel.ForEach(matrices, matrix => matrix.Rotate(degrees));
        }

        //如果发现无效值，则中断循环
        void InvertMatrices(IEnumerable<Matrix> matrices)
        {
            //state ParallelLoopState类型
            Parallel.ForEach(matrices, (matrix, state) =>
            {
                if (!matrix.IsInvertible)
                    state.Stop();
                else
                    matrix.Invert();
            });
        }

        //更常见的情况是可以取消并行循环，这与结束循环不同。
        //结束(stop)循环是在循环内部进行的，而取消(cancel)循环是在循环外部进行的
        void RotateMatrices2(IEnumerable<Matrix> matrices, float degrees, CancellationToken token)
        {
            Parallel.ForEach(matrices,
                new ParallelOptions { CancellationToken = token},
                matrix => matrix.Rotate(degrees));
        }
    }

    class Matrix
    {
        public void Rotate(float degrees)
        { }
        public bool IsInvertible { get; set; }
        public void Invert()
        { }
    }
}
