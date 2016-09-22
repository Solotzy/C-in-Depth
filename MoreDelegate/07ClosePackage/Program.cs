using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JScript;

namespace _07ClosePackage
{
    class Program
    {
        static void EnclosingMethod()
        {
            int outerVariable = 5;
            string capturedVariable = "captured";

            if (DateTime.Now.Hour == 23)
            {
                int normalLocalVarriable = DateTime.Now.Minute;
                Console.WriteLine(normalLocalVarriable);
            }

            MethodInvoker x = delegate()
            {
                string anonLocal = "local to anonymous method";
                Console.WriteLine(capturedVariable + anonLocal);
            };
            x();
        }
        static void Main(string[] args)
        {
        }
    }
}
