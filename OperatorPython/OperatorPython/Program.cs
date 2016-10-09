using System;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace OperatorPython
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            engine.Execute("print 'hello, world'");
            engine.ExecuteFile("HelloWorld.py");
            Console.Read();
        }
    }
}
