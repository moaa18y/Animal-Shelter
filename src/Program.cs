using animal_Shelter.Repos;
using AnimalShelter.src.Controllers;
using AnimalShelter.src.Repos;
using System;
using System.IO;

namespace animal_Shelter
{
    internal class Program
    {
        // Dynamically calculates the path: 
        // 1. Gets the current running directory (bin/Debug/netX.0/)
        // 2. Uses @"..\..\..\" to step up 3 folder levels to your project root
        // 3. Combines it with the data folder and file name
        private static readonly string DataFile = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\data\shelter_data.txt")
        );

        static void Main(string[] args)
        {
            Console.Title = "Animal Shelter Management System";

            // 1. Set up the data layer
            IAnimalRepository repository = new AnimalManager();
            var fileHandler = new ShelterFileHandler(DataFile);

            // 2. Load saved data from the previous session (if any)
            var savedAnimals = fileHandler.LoadAll();
            foreach (var animal in savedAnimals)
                repository.Add(animal);

            // 3. Start the application
            var controller = new AppController(repository);
            controller.Run();

            // 4. Save all data when the user exits
            fileHandler.SaveAll(repository.GetAll());
        }
    }
}
