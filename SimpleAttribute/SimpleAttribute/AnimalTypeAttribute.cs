using System;

namespace SimpleAttribute
{
    public enum Animal
    {
        Dog = 1,
        Cat,
        Bird
    }
    public class AnimalTypeAttribute : Attribute
    {
        public AnimalTypeAttribute(Animal pet)
        {
            thePet = pet;
        }

        protected Animal thePet;

        public Animal Pet
        {
            get { return thePet; }
            set { thePet = value; }
        }
    }
}