using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05AnonymousSort
{
    class Program
    {
        static void SortAndShowFiles(string title, Comparison<FileInfo> sortOrder)
        {
            FileInfo[] files = new DirectoryInfo(@"C:\").GetFiles();

            Array.Sort(files, sortOrder);
            Console.WriteLine(title);
            foreach (FileInfo file in files)
            {
                Console.WriteLine("{0} ({1} bytes)", file.Name, file.Length);
            }
        }
        static void Main(string[] args)
        {
            SortAndShowFiles("Sorted by name:", delegate(FileInfo f1, FileInfo f2)
            {
                return f1.Name.CompareTo(f2.Name);
            });
            Console.WriteLine();
            SortAndShowFiles("Sorted by length:", delegate(FileInfo f1, FileInfo f2)
            {
                return f1.Length.CompareTo(f2.Length);
            });
            Console.Read();
        }
    }
}
