using System;
using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.src.Services.Interfaces;
using AnimalShelter.Shared;
using AnimalShelter.src.Shared.GlobalFiles;

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
            Console.WriteLine("\n========== Animals ==========");
            Console.WriteLine("  1. View All Animals");
            Console.WriteLine("  2. View Animal By Id");

            if (currentUser.Role == EnumRole.Admin)
            {
                Console.WriteLine("  3. Add Animal");
                Console.WriteLine("  4. Update Animal Status");
                Console.WriteLine("  5. Remove Animal");
            }
            else if (currentUser.Role == EnumRole.Employee)
            {
                Console.WriteLine("  3. Update Animal Status");
            }

            Console.WriteLine("  0. Back");
            Console.Write("\nChoose: ");

            var choice = Console.ReadLine()?.Trim();
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
                case "3" when currentUser.Role == EnumRole.Employee:
                    UpdateAnimalStatus();
                    break;
                case "0": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
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
                Console.WriteLine("\nNo animals found.");
                return;
            }

            Console.WriteLine($"\nFound {animals.Count} animal(s):\n");
            foreach (var animal in animals)
                Helpers.PrintAnimal(animal);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ViewAnimalById()
    {
        var id = Helpers.ReadInt("Animal Id: ");
        try
        {
            var animal = _animalService.GetAnimal(id);
            Console.WriteLine();
            Helpers.PrintAnimal(animal);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void AddAnimal()
    {
        Console.WriteLine("\n--- Add New Animal ---");

        var name = Helpers.ReadString("Name: ");
        var age = Helpers.ReadInt("Age: ");
        var species = Helpers.ReadEnumByIndex<EnumAnimalSpecies>("Species");

        var dto = new AddAnimalDto
        {
            Name = name,
            Age = age,
            Species = species
        };

        
        switch (species)
        {
            case EnumAnimalSpecies.Dog:
                Console.WriteLine("\n--- Dog Details ---");
                dto.Breed = Helpers.ReadOptionalString("Breed (press Enter to skip): ");
                dto.Size = Helpers.ReadOptionalEnumByIndex<EnumAnimalSize>("Size");
                break;

            case EnumAnimalSpecies.Cat:
                Console.WriteLine("\n--- Cat Details ---");
                dto.Color = Helpers.ReadOptionalString("Color (press Enter to skip): ");
                dto.IsIndoor = Helpers.ReadOptionalBool("Is Indoor? (y/n, press Enter to skip): ");
                break;

            case EnumAnimalSpecies.Bird:
                Console.WriteLine("\n--- Bird Details ---");
                dto.CanFly = Helpers.ReadOptionalBool("Can Fly? (y/n, press Enter to skip): ");
                break;

            case EnumAnimalSpecies.SmallAnimal:
                Console.WriteLine("\n--- Small Animal Details ---");
                dto.AnimalType = Helpers.ReadOptionalString("Animal Type (press Enter to skip): ");
                dto.IsNocturnal = Helpers.ReadOptionalBool("Is Nocturnal? (y/n, press Enter to skip): ");
                break;
        }

        try
        {
            _animalService.AddAnimal(dto);
            Console.WriteLine("\nAnimal added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void UpdateAnimalStatus()
    {
        var id = Helpers.ReadInt("Animal Id: ");
        var status = Helpers.ReadEnumByIndex<EnumAnimalStatus>("New Status");

        try
        {
            _animalService.UpdateStatus(id, status);
            Console.WriteLine("\nAnimal status updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void RemoveAnimal()
    {
        var id = Helpers.ReadInt("Animal Id: ");
        Console.Write($"Confirm remove animal {id}? (y/N): ");
        if (Console.ReadLine()?.Trim().ToLowerInvariant() != "y")
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        try
        {
            var removed = _animalService.RemoveAnimal(id);
            Console.WriteLine(removed ? "\nAnimal removed successfully." : "\nAnimal not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}