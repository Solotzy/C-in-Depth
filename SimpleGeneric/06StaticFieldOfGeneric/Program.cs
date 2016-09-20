using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06StaticFieldOfGeneric
{
    //证明不同的封闭类型具有不同的静态字段
    class TypeWithField<T>
    {
        public static string field;

        public static void PrintField()
        {
            Console.WriteLine(field + ": " + typeof(T).Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //每个封闭类型有一个静态字段
            TypeWithField<int>.field = "First";
            TypeWithField<string>.field = "Second";
            TypeWithField<DateTime>.field = "Third";
            TypeWithField<int>.field = "four";

            TypeWithField<int>.PrintField();
            TypeWithField<string>.PrintField();
            TypeWithField<DateTime>.PrintField();
            TypeWithField<double>.PrintField();
            Console.Read();
        }
    }
}
