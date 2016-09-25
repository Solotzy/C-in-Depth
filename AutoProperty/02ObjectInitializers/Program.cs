using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ObjectInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置简单属性

            Person tom1 = new Person();
            tom1.Name = "Tom";
            tom1.Age = 9;

            Person tom2 = new Person("Tom");
            tom2.Age = 9;

            Person tom3 = new Person() {Name = "Tom", Age = 9};

            Person tom4 = new Person {Name = "Tom", Age = 9};

            Person tom5 = new Person("Tom") {Age = 9};

            //设置数组
            Person[] family = new Person[]
            {
                new Person{Name = "Holly",Age = 36},
                new Person{Name = "Jon", Age = 36},
                new Person{Name = "Tom", Age = 9},
                new Person{Name = "Robin", Age = 6}, 
            };

            //为嵌入对象设置属性
            Person jack1 = new Person("jack");
            jack1.Age = 9;
            jack1.Home.Country = "UK";
            jack1.Home.Town = "Reading";

            Person jack2 = new Person("Jack")
            {
                Age = 9,
                Home = { Country = "UK", Town = "Reading"}
            };

            //集合初始化程序
            List<string> names1 = new List<string>();
            names1.Add("Holly");
            names1.Add("Jon");
            names1.Add("Tom");
            names1.Add("Robin");

            var names2 = new List<string>
            {
                "Holly",
                "Jon",
                "Tom",
                "Robin"
            };

            List<Person> persons = new List<Person>
            {
                new Person {Name = "Holly", Age = 36},
                new Person {Name = "Jon", Age = 36},
                new Person {Name = "Tom", Age = 9},
                new Person {Name = "Robin", Age = 6},
            };

            var converted = persons.ConvertAll(delegate(Person person)
            {
                //投影
                return new {person.Name, IsAdult = (person.Age >= 18)};
            });
            foreach (var person in converted)
            {
                Console.WriteLine("{0} is an adult? {1}",
                    person.Name, person.IsAdult);
            }

            Console.Read();
        }
    }
}
