using System;
using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.src.Models.GlobalFiles;
using AnimalShelter.src.Services.Interfaces;
using AnimalShelter.Shared;

public class UsersController
{
    private readonly IUserService _userService;
    private readonly IAdoptionService _adoptionService;
    private readonly ICareNoteService _careNoteService;
    private readonly IVaccineService _vaccineService;
    private readonly AnimalsController _animalsController;

    public UsersController(
        IUserService userService,
        IAdoptionService adoptionService,
        ICareNoteService careNoteService,
        IVaccineService vaccineService,
        AnimalsController animalsController)
    {
        _userService = userService;
        _adoptionService = adoptionService;
        _careNoteService = careNoteService;
        _vaccineService = vaccineService;
        _animalsController = animalsController;
    }

    public void ShowMenu(UserDto currentUser)
    {
        if (currentUser.Role == EnumRole.Admin)
        {
            ShowAdminMenu(currentUser);
            return;
        }

        if (currentUser.Role == EnumRole.Employee)
        {
            ShowEmployeeMenu(currentUser);
            return;
        }

        ShowUserMenu(currentUser);
    }

    private void ShowAdminMenu(UserDto currentUser)
    {
        while (true)
        {
            Console.WriteLine("\n-- Admin Menu --");
            Console.WriteLine("1. Animals");
            Console.WriteLine("2. Users");
            Console.WriteLine("3. Adoptions");
            Console.WriteLine("4. Care Notes");
            Console.WriteLine("5. Vaccines");
            Console.WriteLine("0. Back");

            switch (Console.ReadLine())
            {
                case "1": _animalsController.ShowAnimalMenu(currentUser); break;
                case "2": ShowAdminUsersMenu(currentUser); break;
                case "3": ShowAdoptionMenu(currentUser, includeAdminActions: true); break;
                case "4": ShowCareNoteMenu(currentUser, includeAdminActions: true); break;
                case "5": ShowVaccineMenu(currentUser, includeAdminActions: true); break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private void ShowEmployeeMenu(UserDto currentUser)
    {
        while (true)
        {
            Console.WriteLine("\n-- Employee Menu --");
            Console.WriteLine("1. Animals");
            Console.WriteLine("2. Adoptions");
            Console.WriteLine("3. Care Notes");
            Console.WriteLine("4. Vaccines");
            Console.WriteLine("5. My Profile");
            Console.WriteLine("0. Back");

            switch (Console.ReadLine())
            {
                case "1": _animalsController.ShowAnimalMenu(currentUser); break;
                case "2": ShowAdoptionMenu(currentUser, includeAdminActions: false); break;
                case "3": ShowCareNoteMenu(currentUser, includeAdminActions: false); break;
                case "4": ShowVaccineMenu(currentUser, includeAdminActions: false); break;
                case "5": PrintProfile(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private void ShowUserMenu(UserDto currentUser)
    {
        while (true)
        {
            Console.WriteLine("\n-- User Menu --");
            Console.WriteLine("1. Animals");
            Console.WriteLine("2. Adopt Animal");
            Console.WriteLine("3. My Profile");
            Console.WriteLine("0. Back");

            switch (Console.ReadLine())
            {
                case "1": _animalsController.ShowAnimalMenu(currentUser); break;
                case "2": AdoptAnimalInteractive(currentUser); break;
                case "3": PrintProfile(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private void ShowAdminUsersMenu(UserDto currentUser)
    {
        while (true)
        {
            Console.WriteLine("\n-- Users (Admin) --");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("3. Find User By Email");
            Console.WriteLine("4. Update User");
            Console.WriteLine("5. Delete User");
            Console.WriteLine("0. Back");

            switch (Console.ReadLine())
            {
                case "1": AddUserInteractive(currentUser); break;
                case "2": ViewAllUsersInteractive(); break;
                case "3": FindUserByEmailInteractive(); break;
                case "4": UpdateUserInteractive(currentUser); break;
                case "5": DeleteUserInteractive(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private void ShowAdoptionMenu(UserDto currentUser, bool includeAdminActions)
    {
        while (true)
        {
            Console.WriteLine("\n-- Adoptions --");
            Console.WriteLine("1. Adopt Animal");
            Console.WriteLine("2. View All Adoptions");
            Console.WriteLine("3. View Adoption By Id");

            if (includeAdminActions)
            {
                Console.WriteLine("4. Update Adoption");
                Console.WriteLine("5. Delete Adoption");
            }

            Console.WriteLine("0. Back");

            switch (Console.ReadLine())
            {
                case "1": AdoptAnimalInteractive(currentUser); break;
                case "2": ViewAllAdoptionsInteractive(); break;
                case "3": ViewAdoptionByIdInteractive(); break;
                case "4" when includeAdminActions: UpdateAdoptionInteractive(currentUser); break;
                case "5" when includeAdminActions: DeleteAdoptionInteractive(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private void ShowCareNoteMenu(UserDto currentUser, bool includeAdminActions)
    {
        while (true)
        {
            Console.WriteLine("\n-- Care Notes --");
            Console.WriteLine("1. Add Note");
            Console.WriteLine("2. Update Note");
            Console.WriteLine("3. Delete Note");
            Console.WriteLine("0. Back");

            switch (Console.ReadLine())
            {
                case "1": AddCareNoteInteractive(currentUser); break;
                case "2" when includeAdminActions || currentUser.Role == EnumRole.Employee: UpdateCareNoteInteractive(currentUser); break;
                case "3" when includeAdminActions || currentUser.Role == EnumRole.Employee: DeleteCareNoteInteractive(); break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private void ShowVaccineMenu(UserDto currentUser, bool includeAdminActions)
    {
        while (true)
        {
            Console.WriteLine("\n-- Vaccines --");
            Console.WriteLine("1. Add Vaccine");
            Console.WriteLine("2. View All Vaccines");
            Console.WriteLine("3. View Vaccine By Id");

            if (includeAdminActions)
            {
                Console.WriteLine("4. Update Vaccine");
                Console.WriteLine("5. Delete Vaccine");
            }

            Console.WriteLine("0. Back");

            switch (Console.ReadLine())
            {
                case "1": AddVaccineInteractive(currentUser); break;
                case "2": ViewAllVaccinesInteractive(); break;
                case "3": ViewVaccineByIdInteractive(); break;
                case "4" when includeAdminActions: UpdateVaccineInteractive(currentUser); break;
                case "5" when includeAdminActions: DeleteVaccineInteractive(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private void AddUserInteractive(UserDto currentUser)
    {
        var dto = new CreateUserDto
        {
            UserName = Helpers.ReadString("Username: "),
            UserEmail = Helpers.ReadString("Email: "),
            UserPassword = Helpers.ReadString("Password: ")
        };

        Helpers.TryExecute(() => _userService.AddUser(dto, currentUser.Username), "User added successfully.");
    }

    private void ViewAllUsersInteractive()
    {
        Helpers.TryExecute(() =>
        {
            var users = _userService.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }   

            foreach (var user in users)
            {
                
                
                Console.WriteLine($"Id: {user.Id} | {user.Username} | {user.Email} | Role: {user.Role}");
            }
        });
    }

    private void FindUserByEmailInteractive()
    {
        var email = Helpers.ReadString("Email: ");
        Helpers.TryExecute(() =>
        {
            var user = _userService.GetUserByEmail(email);
            Console.WriteLine($"Id: {user.Id}\nUsername: {user.Username}\nEmail: {user.Email}\nRole: {user.Role}");
        });
    }

    private void UpdateUserInteractive(UserDto currentUser)
    {
        var email = Helpers.ReadString("Existing user email: ");
        var updateDto = new UpdateUserDto
        {
            Username = Helpers.ReadOptionalString("New username (leave blank to keep): "),
            Email = Helpers.ReadOptionalString("New email (leave blank to keep): "),
            RoleId = ParseOptionalRoleId()
        };

        Helpers.TryExecute(() => _userService.UpdateUser(email, updateDto, currentUser.Username), "User updated successfully.");
    }

    private void DeleteUserInteractive(UserDto currentUser)
    {
        var email = Helpers.ReadString("Email to delete: ");
        Console.Write($"Confirm delete {email}? (y/N): ");
        if (Console.ReadLine()?.ToLowerInvariant() != "y")
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        Helpers.TryExecute(() => _userService.DeleteUser(email, currentUser.Username), "User deleted.");
    }

    private void AdoptAnimalInteractive(UserDto currentUser)
    {
        var animalId = Helpers.ReadInt("Animal Id: ");

        var adopterId = currentUser.Id;
        if (currentUser.Role == EnumRole.Admin)
        {
            Console.Write("Adopt as another user? (y/N): ");
            if (Console.ReadLine()?.Trim().ToLowerInvariant() == "y")
            {
                var adopterEmail = Helpers.ReadString("Adopter email: ");
                adopterId = _userService.GetUserByEmail(adopterEmail).Id;
            }
        }

        Helpers.TryExecute(() => _adoptionService.AdoptAnimal(animalId, adopterId), "Adoption successful.");
    }

    private void ViewAllAdoptionsInteractive()
    {
        Helpers.TryExecute(() =>
        {
            var adoptions = _adoptionService.GetAllAdoptions();
            if (adoptions == null || adoptions.Count == 0)
            {
                Console.WriteLine("No adoptions found.");
                return;
            }

            foreach (var adoption in adoptions)
                Helpers.PrintAdoption(adoption);
        });
    }

    private void ViewAdoptionByIdInteractive()
    {
        var id = Helpers.ReadInt("Adoption Id: ");
        Helpers.TryExecute(() => Helpers.PrintAdoption(_adoptionService.GetAdoptionById(id)));
    }

    private void UpdateAdoptionInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Adoption Id: ");
        var dto = new UpdateAdoptionDto
        {
            UserId = ParseOptionalIntFromEmail("New adopter email (leave blank to keep): "),
            AnimalId = Helpers.ParseOptionalInt("New animal id (leave blank to keep): "),
            AdoptedAt = Helpers.ReadOptionalDateTime("New adopted date (leave blank to keep): ")
        };

        Helpers.TryExecute(() => _adoptionService.UpdateAdoption(id, dto, currentUser.Username), "Adoption updated.");
    }

    private void DeleteAdoptionInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Adoption Id: ");
        Console.Write($"Confirm delete adoption {id}? (y/N): ");
        if (Console.ReadLine()?.ToLowerInvariant() != "y")
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        Helpers.TryExecute(() => _adoptionService.DeleteAdoption(id, currentUser.Username), "Adoption deleted.");
    }

    private void AddCareNoteInteractive(UserDto currentUser)
    {
        var dto = new AddCareNoteDto
        {
            Title = Helpers.ReadString("Title: "),
            Description = Helpers.ReadString("Description: "),
            AnimalId = Helpers.ReadInt("Animal Id: ")
        };

        Helpers.TryExecute(() => _careNoteService.AddNote(dto, currentUser.Username), "Care note added.");
    }

    private void UpdateCareNoteInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Note Id: ");
        var dto = new UpdateCareNoteDto
        {
            Title = Helpers.ReadString("Title: "),
            Description = Helpers.ReadString("Description: "),
            AnimalId = Helpers.ReadInt("Animal Id: ")
        };

        Helpers.TryExecute(() => _careNoteService.UpdateNote(id, dto, currentUser.Username), "Care note updated.");
    }

    private void DeleteCareNoteInteractive()
    {
        var id = Helpers.ReadInt("Note Id: ");
        Console.Write($"Confirm delete note {id}? (y/N): ");
        if (Console.ReadLine()?.ToLowerInvariant() != "y")
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        Helpers.TryExecute(() => _careNoteService.DeleteNote(id), "Care note deleted.");
    }

    private void AddVaccineInteractive(UserDto currentUser)
    {
        var dto = new AddVaccineDto
        {
            VaccineName = Helpers.ReadString("Vaccine name: "),
            VaccineDescription = Helpers.ReadOptionalString("Description (optional): ") ?? string.Empty,
            AnimalId = Helpers.ReadInt("Animal Id: ")
        };

        Helpers.TryExecute(() => _vaccineService.AddVaccine(dto, currentUser.Username), "Vaccine added.");
    }

    private void ViewAllVaccinesInteractive()
    {
        Helpers.TryExecute(() =>
        {
            var vaccines = _vaccineService.GetAllVaccines();
            if (vaccines == null || vaccines.Count == 0)
            {
                Console.WriteLine("No vaccines found.");
                return;
            }

            foreach (var vaccine in vaccines)
                Helpers.PrintVaccine(vaccine);
        });
    }

    private void ViewVaccineByIdInteractive()
    {
        var id = Helpers.ReadInt("Vaccine Id: ");
        Helpers.TryExecute(() => Helpers.PrintVaccine(_vaccineService.GetVaccineById(id)));
    }

    private void UpdateVaccineInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Vaccine Id: ");
        var dto = new UpdateVaccineDto
        {
            VaccineName = Helpers.ReadString("Vaccine name: "),
            VaccineDescription = Helpers.ReadOptionalString("Description (optional): ") ?? string.Empty,
            AnimalId = Helpers.ReadInt("Animal Id: ")
        };

        Helpers.TryExecute(() => _vaccineService.UpdateVaccine(id, dto, currentUser.Username), "Vaccine updated.");
    }

    private void DeleteVaccineInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Vaccine Id: ");
        Console.Write($"Confirm delete vaccine {id}? (y/N): ");
        if (Console.ReadLine()?.ToLowerInvariant() != "y")
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        Helpers.TryExecute(() => _vaccineService.DeleteVaccineById(id, currentUser.Username), "Vaccine deleted.");
    }

    private static void PrintProfile(UserDto currentUser)
    {
        Console.WriteLine($"Id: {currentUser.Id}");
        Console.WriteLine($"Username: {currentUser.Username}");
        Console.WriteLine($"Email: {currentUser.Email}");
        Console.WriteLine($"Role: {currentUser.Role}");
    }


    private int? ParseOptionalIntFromEmail(string prompt)
    {
        var email = Helpers.ReadOptionalString(prompt);
        if (string.IsNullOrWhiteSpace(email))
            return null;

        return _userService.GetUserByEmail(email).Id;
    }

    private static int? ParseOptionalRoleId()
    {
        var roleInput = Helpers.ReadOptionalString("New role id (1=Admin,2=Employee,3=User) leave blank to keep: ");
        return int.TryParse(roleInput, out var parsed) ? parsed : null;
    }

    
}
