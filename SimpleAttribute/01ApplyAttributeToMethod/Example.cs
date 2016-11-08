using System;

namespace _01ApplyAttributeToMethod
{
    public class Example
    {
        [Obsolete("该方法将在下一个版本中被移除", true)]
        public static int Add(int a, int b)
        {
            return (a + b);
        }
    }
}