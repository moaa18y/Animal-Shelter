using animal_Shelter.Factory;
using animal_Shelter.Repos;
using animal_Shelter.Services;
using animal_Shelter.UI;
using AnimalShelter.src.Controllers;
using AnimalShelter.src.Models;

namespace animal_Shelter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Animal Shelter Management System";

            //Setup Data/Services
            IAnimalRepository repository = new AnimalManager();

            //Setup the App Controller (Injecting the data layer)
            var controller = new AppController(repository);

            //Start the application
            controller.Run();
        }
    }
}
