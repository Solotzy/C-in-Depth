using System;

namespace _03ReflectionGetAttribute
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct,
                    AllowMultiple = true)
    ]
    public class Author : Attribute
    {
        string name;
        public double version;

        public Author(string name)
        {
            this.name = name;
            version = 1.0;
        }

        public string GetName()
        {
            return name;
        }
    }
}