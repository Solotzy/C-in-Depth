/*
 * 使用迭代器块循环遍历文件中的行
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace _07IterationDateTime
{
    class Program
    {
        static IEnumerable<string> ReadLines(string filename)
        {
            using (TextReader reader = File.OpenText(filename))
            {
                string line;
                while ((line = reader.ReadLine())!=null)
                {
                    yield return line;
                }
            }
        }
        static void Main(string[] args)
        {
            foreach (var line in ReadLines("test.txt"))
            {
                Console.WriteLine(line);
            }
            Console.Read();
        }
    }
}
