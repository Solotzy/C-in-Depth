using System;

namespace _03ReflectionGetAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用反射获取指定类型的自定义属性
            PrintAuthorInfo(typeof(FirstClass));
            PrintAuthorInfo(typeof(SecondClass));
            PrintAuthorInfo(typeof(ThirdClass));
            Console.Read();
        }

        private static void PrintAuthorInfo(Type t)
        {
            Console.WriteLine("Author information for {0}", t);

            //使用反射
            Attribute[] attrs = Attribute.GetCustomAttributes(t);

            foreach (var attr in attrs)
            {
                if (attr is Author)
                {
                    Author a = (Author) attr;
                    Console.WriteLine("  {0}, version {1:f}", a.GetName(), a.version);
                }
            }
        }
    }
}
