/*
 * 问题
 *     在默认情况下，一个async方法在被await调用后恢复运行时，会在原来的上下文中运行。
 *     如果是UI上下文，并且有大量的async方法在UI上下文中恢复，就会引起性能上的问题
 * 
 * 解决方案
 *     要避免在上下文中恢复运行，可让await调用ConfigureAwait方法的返回值，
 *     参数continueOnCapturedContext设为false
 * 
 */

using System;
using System.Threading.Tasks;

namespace ch2SimpleAsync
{
    class _27避免上下文延续
    {
        async Task ResumeOnContextAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            //这个方法在同一个上下文中恢复运行
        }

        async Task ResyneWithoutContextAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            //这个方法在恢复运行时，会丢弃上下文
        }
    }
}
