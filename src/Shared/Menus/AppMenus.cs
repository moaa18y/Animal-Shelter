using System;

namespace AnimalShelter.Shared.Menus
{
    public static class AppMenus
    {
        public static void PrintAdminMenu()
        {
            Console.WriteLine("\n========== Admin Menu ==========");
            Console.WriteLine("  1. Animals");
            Console.WriteLine("  2. Users");
            Console.WriteLine("  3. Adoptions");
            Console.WriteLine("  4. Care Notes");
            Console.WriteLine("  5. Vaccines");
            Console.WriteLine("  0. Logout");
            Console.Write("\nChoose: ");
        }

        public static void PrintEmployeeMenu()
        {
            Console.WriteLine("\n========== Employee Menu ==========");
            Console.WriteLine("  1. Animals");
            Console.WriteLine("  2. Adoptions");
            Console.WriteLine("  3. Care Notes");
            Console.WriteLine("  4. Vaccines");
            Console.WriteLine("  5. My Profile");
            Console.WriteLine("  0. Logout");
            Console.Write("\nChoose: ");
        }

        public static void PrintUserMenu()
        {
            Console.WriteLine("\n========== User Menu ==========");
            Console.WriteLine("  1. Browse Animals");
            Console.WriteLine("  2. Adopt Animal");
            Console.WriteLine("  3. My Profile");
            Console.WriteLine("  0. Logout");
            Console.Write("\nChoose: ");
        }

        public static void PrintAdminUsersMenu()
        {
            Console.WriteLine("\n========== Users (Admin) ==========");
            Console.WriteLine("  1. Add User");
            Console.WriteLine("  2. View All Users");
            Console.WriteLine("  3. Find User By Email");
            Console.WriteLine("  4. Update User");
            Console.WriteLine("  5. Delete User");
            Console.WriteLine("  0. Back");
            Console.Write("\nChoose: ");
        }

        public static void PrintAdoptionMenu(bool isAdminOrEmployee)
        {
            Console.WriteLine("\n========== Adoptions ==========");
            Console.WriteLine("  1. Adopt Animal");
            Console.WriteLine("  2. View All Adoptions");
            Console.WriteLine("  3. View Adoption By Id");

            if (isAdminOrEmployee)
            {
                Console.WriteLine("  4. Update Adoption");
                Console.WriteLine("  5. Delete Adoption");
            }

            Console.WriteLine("  0. Back");
            Console.Write("\nChoose: ");
        }

        public static void PrintCareNoteMenu(bool isAdminOrEmployee)
        {
            Console.WriteLine("\n========== Care Notes ==========");
            Console.WriteLine("  1. Add Note");

            if (isAdminOrEmployee)
            {
                Console.WriteLine("  2. Update Note");
                Console.WriteLine("  3. Delete Note");
            }

            Console.WriteLine("  0. Back");
            Console.Write("\nChoose: ");
        }

        public static void PrintVaccineMenu(bool isAdminOrEmployee)
        {
            Console.WriteLine("\n========== Vaccines ==========");
            Console.WriteLine("  1. Add Vaccine");
            Console.WriteLine("  2. View All Vaccines");
            Console.WriteLine("  3. View Vaccine By Id");

            if (isAdminOrEmployee)
            {
                Console.WriteLine("  4. Update Vaccine");
                Console.WriteLine("  5. Delete Vaccine");
            }

            Console.WriteLine("  0. Back");
            Console.Write("\nChoose: ");
        }

        public static void PrintAnimalsMenu(bool canManageAnimals)
        {
            Console.WriteLine("\n========== Animals ==========");
            Console.WriteLine("  1. View All Animals");
            Console.WriteLine("  2. View Animal By Id");

            if (canManageAnimals)
            {
                Console.WriteLine("  3. Add Animal");
                Console.WriteLine("  4. Update Animal Status");
                Console.WriteLine("  5. Remove Animal");
            }
            else
            {
                Console.WriteLine("  3. Update Animal Status");
            }

            Console.WriteLine("  0. Back");
            Console.Write("\nChoose: ");
        }

        public static void PrintLoginHeader()
        {
            Console.WriteLine("\n=== Login ===");
        }

        public static void PrintProfileHeader()
        {
            Console.WriteLine("\n========== My Profile ==========");
        }
    }
}