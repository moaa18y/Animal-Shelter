using animal_Shelter.Repos;
using animal_Shelter.Services;
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


            var fileHandler = new ShelterFileHandler(DataFile);

            IAnimalRepository repoFile = new AnimalFileRepository(fileHandler);
            IAnimalService service = new AnimalService(repoFile);
            var controller = new AppController(service);
            controller.Run();

        }
    }
}
