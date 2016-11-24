/*
 * 问题
 *     创建网格时，需要把数据流块互相链接起来
 * 
 * 解决方案
 *     TPL数据流库提供的块只有一些基本的成员，很多实用的方法实际上是扩张方法
 * 
 * 
 */

using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ch4SimpleDataFlow
{
    class _41链接数据流块
    {
        static async Task LinkDataflow()
        {
            var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
            var subtractBlock = new TransformBlock<int, int>(item => item - 2);

            //建立链接后，从multiplyBlock出来的数据将进入subtractBlock
            multiplyBlock.LinkTo(subtractBlock);
        }

        static async Task PassCompleteInfo()
        {
            var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
            var subtractBlock = new TransformBlock<int, int>(item => item - 2);

            var options = new DataflowLinkOptions {PropagateCompletion = true};
            multiplyBlock.LinkTo(subtractBlock, options);

            //第一个块的完成情况自动传递给第二个块
            multiplyBlock.Complete();
            await subtractBlock.Completion;
        }
    }
}
