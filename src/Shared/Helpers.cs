using System;
using AnimalShelter.src.Shared.Dto.UserDtos;
using AnimalShelter.src.Shared.Dto.Adoption;
using AnimalShelter.src.Shared.Dto.AnimalDtos;
using AnimalShelter.src.Shared.Dto.CareNoteDtos;
using AnimalShelter.src.Shared.Dto.Vaccine;

namespace AnimalShelter.Shared
{
    public static class Helpers
    {
        
        public static string ReadPassword()
        {
            Console.Write("Password: ");
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

        public static int? ParseOptionalInt(string prompt)
        {
            var value = ReadOptionalString(prompt);
            return int.TryParse(value, out var parsed) ? parsed : null;
        }

        public static DateTime? ReadOptionalDateTime(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return DateTime.TryParse(input, out var result) ? result : null;
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

        
        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            while (true)
            {
                Console.WriteLine($"\n{prompt}:");
                int i = 1;
                foreach (var value in Enum.GetValues<TEnum>())
                    Console.WriteLine($"  {i++}. {value}");

                Console.Write("Enter number: ");
                var input = Console.ReadLine()?.Trim();

                
                if (int.TryParse(input, out var idx))
                {
                    var values = Enum.GetValues<TEnum>();
                    if (idx >= 1 && idx <= values.Length)
                        return values[idx - 1];
                }
                else if (Enum.TryParse<TEnum>(input, true, out var byName))
                    return byName;

                Console.WriteLine("Invalid value. Try again.");
            }
        }

        public static TEnum? ReadOptionalEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            Console.WriteLine($"\n{prompt} (press Enter to skip):");
            int i = 1;
            foreach (var value in Enum.GetValues<TEnum>())
                Console.WriteLine($"  {i++}. {value}");

            Console.Write("Enter number or press Enter to skip: ");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (int.TryParse(input, out var idx))
            {
                var values = Enum.GetValues<TEnum>();
                if (idx >= 1 && idx <= values.Length)
                    return values[idx - 1];
            }
            else if (Enum.TryParse<TEnum>(input, true, out var byName))
                return byName;

            return null;
        }

        
        public static TEnum ReadEnumByIndex<TEnum>(string prompt) where TEnum : struct, Enum
            => ReadEnum<TEnum>(prompt);   

        public static TEnum? ReadOptionalEnumByIndex<TEnum>(string prompt) where TEnum : struct, Enum
            => ReadOptionalEnum<TEnum>(prompt);

        
        public static void TryExecute(Action action, string? successMessage = null)
        {
            try
            {
                action();
                if (!string.IsNullOrWhiteSpace(successMessage))
                    Console.WriteLine($"\n{successMessage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        
        public static void PrintAnimal(GetAnimalDto animal)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"  Id      : {animal.Id}");
            Console.WriteLine($"  Name    : {animal.Name}");
            Console.WriteLine($"  Age     : {animal.Age}");
            Console.WriteLine($"  Species : {animal.Species}");
            Console.WriteLine($"  Status  : {animal.Status}");

            
            if (!string.IsNullOrEmpty(animal.Breed))
                Console.WriteLine($"  Breed   : {animal.Breed}");
            if (animal.Size.HasValue)
                Console.WriteLine($"  Size    : {animal.Size}");
            if (!string.IsNullOrEmpty(animal.Color))
                Console.WriteLine($"  Color   : {animal.Color}");
            if (animal.IsIndoor.HasValue)
                Console.WriteLine($"  Indoor  : {(animal.IsIndoor.Value ? "Yes" : "No")}");
            if (animal.CanFly.HasValue)
                Console.WriteLine($"  Can Fly : {(animal.CanFly.Value ? "Yes" : "No")}");
            if (!string.IsNullOrEmpty(animal.AnimalType))
                Console.WriteLine($"  Type    : {animal.AnimalType}");
            if (animal.IsNocturnal.HasValue)
                Console.WriteLine($"  Nocturn.: {(animal.IsNocturnal.Value ? "Yes" : "No")}");

            
            if (animal.Vaccines != null && animal.Vaccines.Count > 0)
            {
                Console.WriteLine($"  Vaccines ({animal.Vaccines.Count}):");
                foreach (var v in animal.Vaccines)
                    Console.WriteLine($"    - {v.VaccineName} on {v.VaccineDate:yyyy-MM-dd}");
            }

            
            if (animal.careNotes != null && animal.careNotes.Count > 0)
            {
                Console.WriteLine($"  Care Notes ({animal.careNotes.Count}):");
                foreach (var n in animal.careNotes)
                    Console.WriteLine($"    - [{n.id}] {n.Title}");
            }

            Console.WriteLine(new string('-', 40));
        }

        public static void PrintAdoption(AdoptionsDto adoption)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"  Adoption Id : {adoption.id}");
            Console.WriteLine($"  Adopted At  : {adoption.AdoptedAt:yyyy-MM-dd HH:mm}");
            if (adoption.Animal != null)
            {
                Console.WriteLine($"  Animal Id   : {adoption.Animal.Id}");
                Console.WriteLine($"  Animal Name : {adoption.Animal.Name}");
                Console.WriteLine($"  Status      : {adoption.Animal.Status}");
            }
            Console.WriteLine(new string('-', 40));
        }

        public static void PrintVaccine(GetVaccineDto vaccine)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"  Id   : {vaccine.Id}");
            Console.WriteLine($"  Name : {vaccine.VaccineName}");
            Console.WriteLine($"  Date : {vaccine.VaccineDate:yyyy-MM-dd}");
            Console.WriteLine(new string('-', 40));
        }

        public static void PrintCareNote(GetCareNoteDto note)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"  Id          : {note.id}");
            Console.WriteLine($"  Title       : {note.Title}");
            Console.WriteLine($"  Description : {note.Description}");
            Console.WriteLine(new string('-', 40));
        }
    }
}