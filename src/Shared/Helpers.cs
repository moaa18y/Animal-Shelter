using System;
using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;

namespace AnimalShelter.Shared
{
    public static class Helpers
    {
        public static string ReadPassword()
        {
            var password = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            }
            while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public static string? ReadOptionalString(string prompt)
        {
            Console.Write(prompt);
            var value = Console.ReadLine();
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out var value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            while (true)
            {
                Console.WriteLine(prompt);
                foreach (var value in Enum.GetValues<TEnum>())
                    Console.WriteLine($"- {value}");

                Console.Write("Enter value: ");
                var input = Console.ReadLine();
                if (Enum.TryParse<TEnum>(input, true, out var result))
                    return result;

                Console.WriteLine("Invalid value. Try again.");
            }
        }

        public static TEnum? ReadOptionalEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            Console.WriteLine(prompt);
            Console.WriteLine("- leave blank to skip");
            foreach (var value in Enum.GetValues<TEnum>())
                Console.WriteLine($"- {value}");

            Console.Write("Enter value: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return Enum.TryParse<TEnum>(input, true, out var result) ? result : null;
        }

        public static bool? ReadOptionalBool(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return input.Trim().ToLowerInvariant() switch
            {
                "y" or "yes" or "true" => true,
                "n" or "no" or "false" => false,
                _ => null
            };
        }

        public static DateTime? ReadOptionalDateTime(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return DateTime.TryParse(input, out var result) ? result : null;
        }

        public static int? ParseOptionalInt(string prompt)
        {
            var value = ReadOptionalString(prompt);
            return int.TryParse(value, out var parsed) ? parsed : null;
        }

        public static void TryExecute(Action action, string? successMessage = null)
        {
            try
            {
                action();
                if (!string.IsNullOrWhiteSpace(successMessage))
                    Console.WriteLine(successMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintAnimal(GetAnimalDto animal)
        {
            Console.WriteLine($"Id: {animal.Id}");
            Console.WriteLine($"Name: {animal.Name}");
            Console.WriteLine($"Age: {animal.Age}");
            Console.WriteLine($"Species: {animal.Species}");
            Console.WriteLine($"Status: {animal.Status}");
            Console.WriteLine($"Breed: {animal.Breed}");
            Console.WriteLine($"Size: {animal.Size}");
            Console.WriteLine($"Color: {animal.Color}");
            Console.WriteLine($"Is Indoor: {animal.IsIndoor}");
            Console.WriteLine($"Can Fly: {animal.CanFly}");
            Console.WriteLine($"Animal Type: {animal.AnimalType}");
            Console.WriteLine($"Is Nocturnal: {animal.IsNocturnal}");
            Console.WriteLine();
        }

        public static void PrintAdoption(AdoptionsDto adoption)
        {
            Console.WriteLine($"Adoption Id: {adoption.id}");
            Console.WriteLine($"Adopted At: {adoption.AdoptedAt}");
            if (adoption.Animal != null)
            {
                Console.WriteLine($"Animal Id: {adoption.Animal.Id}");
                Console.WriteLine($"Animal Name: {adoption.Animal.Name}");
                Console.WriteLine($"Animal Status: {adoption.Animal.Status}");
            }
            Console.WriteLine();
        }

        public static void PrintVaccine(GetVaccineDto vaccine)
        {
            Console.WriteLine($"Id: {vaccine.Id}");
            Console.WriteLine($"Name: {vaccine.VaccineName}");
            Console.WriteLine($"Date: {vaccine.VaccineDate}");
            Console.WriteLine();
        }

        public static void PrintCareNote(GetCareNoteDto note)
        {
            Console.WriteLine($"Id: {note.id}");
            Console.WriteLine($"Title: {note.Title}");
            Console.WriteLine($"Description: {note.Description}");
            Console.WriteLine();
        }
    }
}
