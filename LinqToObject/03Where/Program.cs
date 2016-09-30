using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _03Where
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 使用多个Where子句的查询表达式
             * User tim = SampleData.Users.TesterTim;
             * 
             * var query = from defect in SampleData.AllDefects
             *             where defect.Status != Status.Closed
             *             where defect.AssignedTo == tim
             *             select defect.Summary;
             * foreach(var summary in query)
             * {
             *     Console.WriteLine(summary);
             * }
             * 等同于
             * SampleData.AllDefects.Where(defect => defect.Status != Status.Closed)
             *                      .Where(defect => defect.AssignedTo == tim)
             *                      .Select(defect => defect.Summary);
             * 
             * 当然，我们可以编写合并两个条件的单一where子句，来替换多个where子句的使用
             * 在某些情况下，这样可以提高性能，但也要考虑查询表达式的可读性
             * 
             * 使用orderby子句进行排序
             * 先按严重度排序，而后按最后修改时间排序
             * User tim = SampleData.Users.TesterTim;
             * var query = from defect in SampleData.AllDefects
             *             where defect.Status != Status.Closed
             *             where defect.AssignedTo == tim
             *             orderby defect.Severity descending, defect.LastModified
             *             select defect;
             * foreach(var defect in query)
             * {
             *     Console.WriteLine("{0}: {1} ({2:d})",
             *                       defect.Severity, defect.Summary, defect.LastModified);
             * }
             * 等同于
             * SampleData.AllDefects.Where(defect => defect.Status != Status.Closed)
             *                      .Where(defect => defect.AssignedTo == tim)
             *                      .OrderByDescending(defect => defect.Severity)
             *                      .ThenBy(defect => defect.LastModified);
             * OrderBy假设它对排序规则起决定作用
             * 而ThenBy可理解为对之前的一个或多个排序规则起辅助作用                     
             * 
             */
        }
    }
}
