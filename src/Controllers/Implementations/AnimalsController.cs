using System;
using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.src.Models.GlobalFiles;
using AnimalShelter.src.Services.Interfaces;
using AnimalShelter.Shared;

public class AnimalsController
{
    private readonly IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    public void ShowAnimalMenu(UserDto currentUser)
    {
        while (true)
        {
            Console.WriteLine("\n-- Animals --");
            Console.WriteLine("1. View All Animals");
            Console.WriteLine("2. View Animal By Id");

            if (currentUser.Role == EnumRole.Admin)
            {
                Console.WriteLine("3. Add Animal");
                Console.WriteLine("4. Update Animal Status");
                Console.WriteLine("5. Remove Animal");
            }
            else if (currentUser.Role == EnumRole.Employee)
            {
                Console.WriteLine("3. Update Animal Status");
            }

            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": ViewAllAnimals(); break;
                case "2": ViewAnimalById(); break;
                case "3" when currentUser.Role == EnumRole.Admin:
                    AddAnimal();
                    break;
                case "4" when currentUser.Role == EnumRole.Admin:
                    UpdateAnimalStatus();
                    break;
                case "5" when currentUser.Role == EnumRole.Admin:
                    RemoveAnimal();
                    break;
                case "3" when currentUser.Role == EnumRole.Employee || currentUser.Role == EnumRole.Admin:
                    UpdateAnimalStatus();
                    break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private void ViewAllAnimals()
    {
        try
        {
            var animals = _animalService.GetAllAnimals();
            if (animals.Count == 0)
            {
                Console.WriteLine("No animals found.");
                return;
            }

            foreach (var animal in animals)
                Helpers.PrintAnimal(animal);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ViewAnimalById()
    {
        var id = Helpers.ReadInt("Animal Id: ");
        try
        {
            var animal = _animalService.GetAnimal(id);
            Helpers.PrintAnimal(animal);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void AddAnimal()
    {
        var dto = new AddAnimalDto
        {
            Name = Helpers.ReadString("Name: "),
            Age = Helpers.ReadInt("Age: "),
            Species = Helpers.ReadEnum<EnumAnimalSpecies>("Species"),
            Breed = Helpers.ReadOptionalString("Breed (optional): "),
            Size = Helpers.ReadOptionalEnum<EnumAnimalSize>("Size (optional): "),
            Color = Helpers.ReadOptionalString("Color (optional): "),
            IsIndoor = Helpers.ReadOptionalBool("Is Indoor? (optional y/n): "),
            CanFly = Helpers.ReadOptionalBool("Can Fly? (optional y/n): "),
            AnimalType = Helpers.ReadOptionalString("Animal Type (optional): "),
            IsNocturnal = Helpers.ReadOptionalBool("Is Nocturnal? (optional y/n): ")
        };

        try
        {
            _animalService.AddAnimal(dto);
            Console.WriteLine("Animal added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void UpdateAnimalStatus()
    {
        var id = Helpers.ReadInt("Animal Id: ");
        var status = Helpers.ReadEnum<EnumAnimalStatus>("New Status");

        try
        {
            _animalService.UpdateStatus(id, status);
            Console.WriteLine("Animal status updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void RemoveAnimal()
    {
        var id = Helpers.ReadInt("Animal Id: ");

        try
        {
            var removed = _animalService.RemoveAnimal(id);
            Console.WriteLine(removed ? "Animal removed successfully." : "Animal not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
