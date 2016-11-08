using System;

namespace _02MyAuthor
{
    /// <summary>
    /// 限定Author特性仅能应用于类和结构
    /// </summary>
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct,
                    AllowMultiple = true)
    ]
    public class Author : Attribute
    {
        private string name;
        public double version;

        /// <summary>
        /// 构造函数的参数是自定义特性的定位参数
        /// name是定位参数 version是命名参数(public)   任何公开的读写字段或属性都是命名参数
        /// </summary>
        /// <param name="name"></param>
        public Author(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }
}