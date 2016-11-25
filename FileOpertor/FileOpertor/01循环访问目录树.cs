using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileOpertor
{
    [TestClass]
    class _01循环访问目录树_递归
    {
        static StringCollection log = new StringCollection();

        [TestMethod]
        public static void TestMethod()
        {
            string[] drives = Environment.GetLogicalDrives();

            foreach (var drive in drives)
            {
                DriveInfo driveInfo = new DriveInfo(drive);

                if (!driveInfo.IsReady)
                {
                    Console.WriteLine("驱动器 {0} 不可读取", driveInfo.Name);
                    continue;
                }
                DirectoryInfo rootDir = driveInfo.RootDirectory;
                //WalkDirectoryTree(rootDir);
                TraverseTree(rootDir.Name);
            }

            Console.WriteLine("限制访问的文件：");
            foreach (var s in log)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        static void TraverseTree(string root)
        {
            Stack<string> dirs = new Stack<string>(20);

            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs = null;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    log.Add(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    log.Add(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                foreach (var file in files)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(file);
                        Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                foreach (var str in subDirs)
                {
                    dirs.Push(str);
                }
            }
        }

        /// <summary>
        /// 递归遍历目录树，但是如果目录树很大且嵌套很深，则可能会引起堆栈溢出异常
        /// </summary>
        /// <param name="root"></param>
        static void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }
                // 当权限不足时抛出异常
            catch (UnauthorizedAccessException e)
            {
                log.Add(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (var fileInfo in files)
                {
                    Console.WriteLine(fileInfo.FullName);
                }

                subDirs = root.GetDirectories();

                foreach (var directoryInfo in subDirs)
                {
                    WalkDirectoryTree(directoryInfo);
                }
            }
        }
    }
}
