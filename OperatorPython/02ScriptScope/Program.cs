using System;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace _02ScriptScope
{
    class Program
    {
        static void Main(string[] args)
        {
            string python = @"
            text = 'hello'
            output = input + 1
            ";
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("input", 10);
            engine.Execute(python, scope);
            Console.WriteLine(scope.GetVariable("text"));
            Console.WriteLine(scope.GetVariable("input"));
            Console.WriteLine(scope.GetVariable("output"));
            Console.Read();
        }
    }
}
