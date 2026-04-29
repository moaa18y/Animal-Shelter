using animal_Shelter.Factory;
using animal_Shelter.Repos;
using animal_Shelter.Services;
using animal_Shelter.UI;
using AnimalShelter.src.Models;

namespace animal_Shelter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            IAnimalRepository repo = new AnimalManager();

            IAnimalService service = new AnimalService(repo);

            Program p = new Program();

            int choice;
            do{
                PrintMenu();
                choice = ConsoleInput.ReadInt("Your choice: ", 1, 6);
                service.GetAllAnimals();

                switch (choice)
                {
                    case 1: p.AddAnimal(service); break;
                    case 2: foreach (var animal in service.GetAllAnimals())
                        { Console.WriteLine(animal.GetSpeciesInfo());}
                        break;
                       
                    case 3: p.SearchAnimal(service); break;
                    //case 4: UpdateAnimalStatus(); break;
                    case 5: p.RemoveAnimal(service); break;
                }
            }while (choice != 6);

            


        }


        #region remove
        private void RemoveAnimal(IAnimalService service)
        {
            Console.WriteLine("Remove an Animal");

            Console.WriteLine(service.GetAllAnimals());

            int id = ConsoleInput.ReadInt("Enter animal ID to remove (0 to cancel): ", 0, int.MaxValue);

            if (id == 0)
            {
                Console.WriteLine("Removal cancelled.");
                Pause();
                return;
            }

            try
            {
                
                var animal = service.GetAnimal(id);

                bool confirm = ConsoleInput.ReadBool($"Remove {animal.Name}? (y/n): ");

                if (!confirm)
                {
                    Console.WriteLine("Removal cancelled.");
                    Pause();
                    return;
                }

                service.RemoveAnimal(id);

                Console.WriteLine($"{animal.Name} (ID {id}) has been removed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Pause();
        }
        #endregion



        #region Search_Animal(name,id,status)

        private void SearchAnimal(IAnimalService service)
        {
            Console.WriteLine("Search Animals");

            Console.WriteLine("1. Name");
            Console.WriteLine("2. ID");
            Console.WriteLine("3. Status");

            int searchType = ConsoleInput.ReadInt("Search type (1-3): ", 1, 3);

            try
            {
                switch (searchType)
                {
                    case 1:
                        {
                            string name = ConsoleInput.ReadString("Name to search: ");
                            var results = service.SearchByName(name);

                            foreach (var animal in results)
                            {
                                Console.WriteLine(animal.GetSpeciesInfo());
                            }
                            break;
                        }

                    case 2:
                        {
                            int id = ConsoleInput.ReadInt("Enter ID: ", 1, int.MaxValue);

                            var animal = service.GetAnimal(id);
                            
                                Console.WriteLine(animal.GetSpeciesInfo());
                            
                            break;
                        }

                    case 3:
                        {
                            var statusValues = Enum.GetValues<AnimalStatus>();
                            foreach (AnimalStatus s in statusValues)
                                Console.WriteLine($"{(int)s}. {s}");

                            int statusInt = ConsoleInput.ReadInt("Select status: ", 0, statusValues.Length - 1);

                            var results = service.GetByStatus((AnimalStatus)statusInt);
                            foreach (var animal in results)
                            {
                                Console.WriteLine(animal.GetSpeciesInfo());
                            }
                            //AnimalDisplay.ShowSearchResults(results, $"status = {(AnimalStatus)statusInt}");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Pause();
        }

        #endregion


        #region Add_Animal

        private void AddAnimal(IAnimalService service)
        {
            Console.WriteLine("Add a New Animal");
            Console.WriteLine("  Select animal type:");
            Console.WriteLine("    1. Dog");
            Console.WriteLine("    2. Cat");
            Console.WriteLine("    3. Bird");
            Console.WriteLine("    4. Small Animal");
            Console.WriteLine();

            int type = ConsoleInput.ReadInt("Animal type(1-4): ", 1, 4);

            try
            {
                service.AddAnimal(type);
                Console.WriteLine("Animal added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Pause();
        }

        #endregion

        #region print_Menu
        private static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ┌──────────────────────────────┐");
            Console.WriteLine("  │         MAIN MENU            │");
            Console.WriteLine("  ├──────────────────────────────┤");
            Console.WriteLine("  │  1. Add a new animal         │");
            Console.WriteLine("  │  2. View all animals         │");
            Console.WriteLine("  │  3. Search by name or ID     │");
            Console.WriteLine("  │  4. Update an animal's status│");
            Console.WriteLine("  │  5. Remove an animal         │");
            Console.WriteLine("  │  6. Save & Exit              │");
            Console.WriteLine("  └──────────────────────────────┘");
            Console.ResetColor();
            Console.WriteLine();
        }
        #endregion



        #region Pause
        private static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n  Press Enter to return to the menu...");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            //PrintBanner();
        }
        #endregion
    }
}
