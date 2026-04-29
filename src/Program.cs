using AnimalShelter.src.Models;

namespace AnimalShelter.src
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Animal Shelter!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View all animals");
            Console.WriteLine("2. Add a new animal");
            Console.WriteLine("3. Update animal status");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

            SmallAnimal rabbit = new SmallAnimal(1, "Thumper", 2, "Rabbit", "Forest", true, AnimalStatus.Adopted);
            Bird bird = new Bird(2, "Lolly", 5, "Parrot", true, "Small", AnimalStatus.Adopted);
            Cat cat = new Cat(3, "Whiskers", 3, true, "Siamese", true, AnimalStatus.PendingAdoption);
            Dog dog = new Dog(4, "Buddy", 4, "Labrador", true, "Large", AnimalStatus.Available);

            Console.WriteLine(rabbit.GetSpeciesInfo());
            Console.WriteLine(bird.GetSpeciesInfo());
            Console.WriteLine(cat.GetSpeciesInfo());
            Console.WriteLine(dog.GetSpeciesInfo());
        }
    }
}