/*
 * 问题：
 *     如何实现一个具有异步签名的同步方法。
 *     如果从异步接口或基类继承代码，但希望用同步的方法来实现它，就会出现这种情况。
 *     对异步代码做单元测试，以及用简单的生成方法存根(sub)或者模拟对象(mock)来产生异步接口，
 *     这两种情况下都可使用这种技术
 *     
 * 解决方案
 *     可以使用Task.FromResult方法创建并返回一个新的Task<T>对象这个Task对象是
 *     已经完成的，并有指定的值
 */

using System.Threading.Tasks;

namespace ch2SimpleAsync
{
    interface IMyAsyncInterface
    {
        Task<int> GetValueAsync();
    }

    class MySynchronousImplementation : IMyAsyncInterface
    {
        public Task<int> GetValueAsync()
        {
            return Task.FromResult(13);
        }
    }
    class _22返回完成的任务
    {

    }
}
