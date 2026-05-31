using System;
using AnimalShelter.src.Shared.Dto.Adoption;
using AnimalShelter.src.Shared.Dto.AnimalDtos;
using AnimalShelter.src.Shared.Dto.CareNoteDtos;
using AnimalShelter.src.Shared.Dto.Vaccine;

namespace AnimalShelter.Shared
{
    public static partial class Helpers
    {
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

        public static void PrintUserProfile(UserDto profile)
        {
            Console.WriteLine("\n========== My Profile ==========");
            Console.WriteLine($"  Username : {profile.Username}");
            Console.WriteLine($"  Email    : {profile.Email}");
            Console.WriteLine($"  Role     : {profile.Role}");

            if (profile.Adoptions != null && profile.Adoptions.Count > 0)
            {
                Console.WriteLine($"\n  My Adoptions ({profile.Adoptions.Count}):");
                foreach (var a in profile.Adoptions)
                    Console.WriteLine($"    - [{a.id}] {a.Animal?.Name} on {a.AdoptedAt:yyyy-MM-dd}");
            }

            Console.WriteLine(new string('=', 34));
        }
    }
}