/*
 * 演示委托返回类型的协变性
 */
using System;
using System.IO;
namespace ConvarianceOfReturn
{
    class Program
    {
        //声明返回Stream的委托类型
        delegate Stream StreamFactory();
        //声明返回MemoryStream的方法
        static MemoryStream GenerateSampleData()
        {
            byte[] buffer = new byte[16];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte) i;
            }
            return new MemoryStream(buffer);
        }
        static void Main(string[] args)
        {
            //利用协变性来转换方法组
            StreamFactory factory = GenerateSampleData;
            //调用委托以获得Stream
            using (Stream stream = factory())
            {
                int data;
                while ((data = stream.ReadByte())!=-1)
                {
                    Console.WriteLine(data);
                }
            }
            Console.Read();
        }
    }
}
