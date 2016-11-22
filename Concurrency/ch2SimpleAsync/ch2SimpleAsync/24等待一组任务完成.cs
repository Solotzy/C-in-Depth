/*
 * 问题
 *     执行几个任务，等待他们全部完成
 * 
 * 解决方案
 *     框架提供的Task.WhenAll方法可以实现这个功能。
 *     这个方法的输入为若干个任务，当所有任务都完成时，返回一个完成的Task对象
 *     
 *     Task task1 = Task.Delay(TimeSpan.FromSeconds(3));
 *     Task task2 = Task.Delay(TimeSpan.FromSeconds(5));
 *     Task task3 = Task.Delay(TimeSpan.FromSeconds(7));
 *     
 *     await Task.WhenAll(task1, task2, task3);   
 *     
 *     如果所有的任务的结果类型相同，并且全部成功的完成，则Task.WhenAll返回存
 *     有每个任务执行结果的数组
 *     int[] results = await Task.WhenAll(task1, task2, task3);
 *     "result" 含有 {3, 5, 7}
 * 
 */

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ch2SimpleAsync
{
    class _24等待一组任务完成
    {
        static async Task<string> DownloadAllAsync(IEnumerable<string> urls)
        {
            var httpClient = new HttpClient();

            //定义每一个url的使用方法
            var downloads = urls.Select(url => httpClient.GetStringAsync(url));
            //注意，到这里，序列还没有求值，所以所有任务都还没真正启动

            //下面，所有的URL下载同步开始
            Task<string>[] downloadTasks = downloads.ToArray();
            //到这里，所有的任务已经开始执行了

            //用异步方式等待所有下载完成
            string[] htmlPages = await Task.WhenAll(downloadTasks);

            return string.Concat(htmlPages);
        }
    }
}
