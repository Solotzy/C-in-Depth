using System.Collections.Generic;

namespace _02ObjectInitializers
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        List<Person> firends = new List<Person>();
        public List<Person> Friends { get { return firends; } }

        Location home = new Location();
        public Location Home { get { return home; } }
        public Person() { }

        public Person(string name)
        {
            Name = name;
        }
    }

    public class Location
    {
        public string Country { get; set; }
        public string Town { get; set; }
    }
}