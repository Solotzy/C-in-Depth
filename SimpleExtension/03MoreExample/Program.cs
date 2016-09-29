using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03MoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 聚合：工资汇总
             * 假定要对各部门的总工资制作报表，工资最高的部门排在前面
             * company.Departments
             *        .Select(dept => new
             *        {
             *            dept.Name,
             *            Cost = dept.Employees.Sum(person => person.Salary)
             *        })
             *        .OrderbyDescending(deptWithCost => deptWithCost.Cost);
             */

            /* 分组：统计分配给开发者的bug数量
             * bugs.GroupBy(bug => bug.AssignedTo)
             *     .Select(list => new { Developer = list.Key, Count = list.Count() })
             *     .OrderByDescending(x => x.Count);
             */
        }
    }
}
