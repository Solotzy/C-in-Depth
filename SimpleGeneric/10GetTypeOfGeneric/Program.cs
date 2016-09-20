using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10GetTypeOfGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            string listTypeName = "System.Collections.Generic.List`1";
            Type defByName = Type.GetType(listTypeName);

            Type closedByName = Type.GetType(listTypeName + "[System.String]");
            Type closedByMethod = defByName.MakeGenericType(typeof(string));
            Type closeByTypeof = typeof(List<string>);

            Console.WriteLine(closedByMethod == closedByName);
            Console.WriteLine(closedByName == closeByTypeof);

            Type defByTypeof = typeof(List<>);
            Type defByMethod = closedByName.GetGenericTypeDefinition();

            Console.WriteLine(defByMethod == defByName);
            Console.WriteLine(defByName == defByTypeof);

            Console.Read();
        }
    }
}
