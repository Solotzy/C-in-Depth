using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07StaticConstructorOfGeneric
{
    public class Outer<T>
    {
        public class Inner<U, V>
        {
            static Inner()
            {
                Console.WriteLine("Outer<{0}>.Inner<{1}, {2}>",
                    typeof(T).Name,
                    typeof(U).Name,
                    typeof(V).Name);
            }
            public static void DummyMethod() { }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //第一次调用，不管使用什么类型，都会导致Inner类型的初始化
            //每个不同的类型实参列表都被看做一个不同的封闭类型
            Outer<int>.Inner<string, DateTime>.DummyMethod();
            Outer<string>.Inner<int,int>.DummyMethod();
            Outer<object>.Inner<string, object>.DummyMethod();
            Outer<string>.Inner<string,object>.DummyMethod();
            Outer<object>.Inner<object,string>.DummyMethod();
            //第二次调用，静态构造函数不会执行
            Outer<string>.Inner<int,int>.DummyMethod();
            Console.Read();
        }
    }
}
