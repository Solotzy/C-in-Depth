/*
 * 问题
 *     执行若干个任务，只需要对其中任意一个的完成进行响应。
 *     主要用于：对一个操作进行多种独立的尝试，只要一个尝试完成，任务就算完成。
 *     例如：同时向多个Web服务询问股票价格，但是只关心第一个响应的。
 * 
 * 解决方案
 *     使用Task.WhenAny方法。
 * 
 */

using System.Net.Http;
using System.Threading.Tasks;

namespace ch2SimpleAsync
{
    class _25等待任意一个任务完成
    {
        private static async Task<int> FirstRespondlingUrlAsync(string urlA, string urlB)
        {
            var httpClient = new HttpClient();

            //并发地开始两个下载任务
            Task<byte[]> downloadTaskA = httpClient.GetByteArrayAsync(urlA);
            Task<byte[]> downloadTaskB = httpClient.GetByteArrayAsync(urlB);

            //等待任意一个任务完成
            Task<byte[]> completedTask =
                await Task.WhenAny(downloadTaskA, downloadTaskB);

            //返回从Url得到的数据的长度
            byte[] data = await completedTask;
            return data.Length;
        }
    }
}
