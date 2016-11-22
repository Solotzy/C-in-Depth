/*
 * 问题
 *     并行任务的结构和数量要在运行时才能确定，这是一种更复杂的并行编程
 * 
 * 解决方案
 *     任务并行库(TPL)是以Task类为中心构建的。
 *     Task类的功能很强大,Parallel类和并行LINQ只是为了使用方便，从而
 *     对Task类进行了封装。实现动态并行最简单的做法就是直接使用Task类。
 *     
 * 
 */

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ch3SimpleTPL
{
    class _34动态并行
    {
        /* 下面的例子对二叉树的每个节点进行处理，并且该处理是很耗资源的。
         * 二叉树的结构在运行时才能确定，因此非常适合采用动态并行。
         * Traverse方法处理当前节点，然后创建两个子任务，每个子任务对应一个子节点
         * (本例中，假定必须先处理父节点，然后才能处理子节点)。
         * ProcessTree方法启动处理过程，创建一个更高层的父任务，并等待任务完成
         */

        void Traverse(Node current)
        {
            DoExpensiveActionOnNode(current);
            if (current.Left != null)
            {
                Task.Factory.StartNew(() => Traverse(current.Left),
                    CancellationToken.None,
                    TaskCreationOptions.AttachedToParent,
                    TaskScheduler.Default);
            }
            if (current.Right != null)
            {
                Task.Factory.StartNew(() => Traverse(current.Right),
                    CancellationToken.None,
                    TaskCreationOptions.AttachedToParent,
                    TaskScheduler.Default);
            }
        }

        public void ProcessTree(Node root)
        {
            var task = Task.Factory.StartNew(() => Traverse(root),
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default);
            task.Wait();
        }

        private void DoExpensiveActionOnNode(Node current)
        {
            throw new NotImplementedException();
        }
    }

    internal class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
