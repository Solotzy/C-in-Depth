namespace SimpleAttribute
{
    public class AnimalTypeTestClass
    {
        [AnimalType(Animal.Dog)]
        public void DogMethod() { }

        [AnimalType(Animal.Cat)]
        public void CatMethod() { }

        [AnimalType(Animal.Bird)]
        public void BirdMethod() { }
    }
}