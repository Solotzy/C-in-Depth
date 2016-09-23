/*
 * 使用迭代器块循环遍历文件中的行
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace _07IterationText
{
    public class Program
    {
        //#1
        public static IEnumerable<string> ReadLines(string filename)
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

        //#2
        public delegate TResult Func<TResult>();
        static IEnumerable<string> ReadLines(Func<TextReader> provider)
        {
            using (TextReader reader = provider())
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        //#3
        //static IEnumerable<string> ReadLines(string filename)
        //{
        //    return ReadLines(filename, Encoding.UTF8);
        //}

        //static IEnumerable<string> ReadLines(string filename, Encoding encoding)
        //{
        //    return ReadLines(delegate
        //    {
        //        return File.OpenText(filename);
        //    });
        //}
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
