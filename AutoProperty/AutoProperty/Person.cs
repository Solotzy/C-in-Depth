namespace AutoProperty
{
    public class Person
    {
        //声明公有取值方法的属性
        public string Name { get; private set; }
        public int Age { get; private set; }

        //声明私有的静态属性和锁
        private static int InstanceCounter { get; set; }
        private static readonly object counterLock = new object();

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            //在访问静态属性时使用锁
            lock (counterLock)
            {
                InstanceCounter++;
            }
        }
    }
}