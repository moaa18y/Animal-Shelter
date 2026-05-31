using System;
using AnimalShelter.src.Shared.Dto;
using AnimalShelter.src.Shared.Dto.UserDtos;
using AnimalShelter.src.Shared.CustomException;
using AnimalShelter.src.Shared.Enums;
using AnimalShelter.src.Services.Interfaces;
using AnimalShelter.Shared;
using AnimalShelter.Shared.Menus;

public class UsersController
{
    private readonly IUserService _userService;
    private readonly IAdoptionService _adoptionService;
    private readonly ICareNoteService _careNoteService;
    private readonly IVaccineService _vaccineService;
    private readonly AnimalsController _animalsController;
    private readonly IAuthorizationService _authService;   

    public UsersController(
        IUserService userService,
        IAdoptionService adoptionService,
        ICareNoteService careNoteService,
        IVaccineService vaccineService,
        AnimalsController animalsController,
        IAuthorizationService authService)
    {
        _userService = userService;
        _adoptionService = adoptionService;
        _careNoteService = careNoteService;
        _vaccineService = vaccineService;
        _animalsController = animalsController;
        _authService = authService;
    }

    public void ShowMenu(UserDto currentUser)
    {
        
        if (_authService.CanManage(currentUser))
        {
            ShowAdminMenu(currentUser);
            return;
        }

        if (_authService.CanControll(currentUser))
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
            AppMenus.PrintAdminMenu();

            switch (Console.ReadLine()?.Trim())
            {
                case "1": _animalsController.ShowAnimalMenu(currentUser); break;
                case "2": ShowAdminUsersMenu(currentUser); break;
                case "3": ShowAdoptionMenu(currentUser, isAdminOrEmployee: true); break;
                case "4": ShowCareNoteMenu(currentUser, isAdminOrEmployee: true); break;
                case "5": ShowVaccineMenu(currentUser, isAdminOrEmployee: true); break;
                case "0": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    
    private void ShowEmployeeMenu(UserDto currentUser)
    {
        while (true)
        {
            AppMenus.PrintEmployeeMenu();

            switch (Console.ReadLine()?.Trim())
            {
                case "1": _animalsController.ShowAnimalMenu(currentUser); break;
                case "2": ShowAdoptionMenu(currentUser, isAdminOrEmployee: true); break;
                case "3": ShowCareNoteMenu(currentUser, isAdminOrEmployee: true); break;
                case "4": ShowVaccineMenu(currentUser, isAdminOrEmployee: true); break;
                case "5": PrintProfile(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    
    private void ShowUserMenu(UserDto currentUser)
    {
        while (true)
        {
            AppMenus.PrintUserMenu();

            switch (Console.ReadLine()?.Trim())
            {
                case "1": _animalsController.ShowAnimalMenu(currentUser); break;
                case "2": AdoptAnimalInteractive(currentUser); break;
                case "3": PrintProfile(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    
    private void ShowAdminUsersMenu(UserDto currentUser)
    {
        while (true)
        {
            AppMenus.PrintAdminUsersMenu();

            switch (Console.ReadLine()?.Trim())
            {
                case "1": AddUserInteractive(currentUser); break;
                case "2": ViewAllUsersInteractive(); break;
                case "3": FindUserByEmailInteractive(); break;
                case "4": UpdateUserInteractive(currentUser); break;
                case "5": DeleteUserInteractive(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    
    private void ShowAdoptionMenu(UserDto currentUser, bool isAdminOrEmployee)
    {
        while (true)
        {
            AppMenus.PrintAdoptionMenu(isAdminOrEmployee);

            switch (Console.ReadLine()?.Trim())
            {
                case "1": AdoptAnimalInteractive(currentUser); break;
                case "2": ViewAllAdoptionsInteractive(); break;
                case "3": ViewAdoptionByIdInteractive(); break;
                case "4" when isAdminOrEmployee: UpdateAdoptionInteractive(currentUser); break;
                case "5" when isAdminOrEmployee: DeleteAdoptionInteractive(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    
    private void ShowCareNoteMenu(UserDto currentUser, bool isAdminOrEmployee)
    {
        while (true)
        {
            AppMenus.PrintCareNoteMenu(isAdminOrEmployee);

            switch (Console.ReadLine()?.Trim())
            {
                case "1": AddCareNoteInteractive(currentUser); break;
                case "2" when isAdminOrEmployee: UpdateCareNoteInteractive(currentUser); break;
                case "3" when isAdminOrEmployee: DeleteCareNoteInteractive(); break;
                case "0": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    
    private void ShowVaccineMenu(UserDto currentUser, bool isAdminOrEmployee)
    {
        while (true)
        {
            AppMenus.PrintVaccineMenu(isAdminOrEmployee);

            switch (Console.ReadLine()?.Trim())
            {
                case "1": AddVaccineInteractive(currentUser); break;
                case "2": ViewAllVaccinesInteractive(); break;
                case "3": ViewVaccineByIdInteractive(); break;
                case "4" when isAdminOrEmployee: UpdateVaccineInteractive(currentUser); break;
                case "5" when isAdminOrEmployee: DeleteVaccineInteractive(currentUser); break;
                case "0": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    
    private void AddUserInteractive(UserDto currentUser)
    {
        Console.WriteLine("\n--- Add User ---");
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
                Console.WriteLine("\nNo users found.");
                return;
            }

            Console.WriteLine($"\nFound {users.Count} user(s):\n");
            Console.WriteLine($"  {"Id",-5} {"Username",-20} {"Email",-35} {"Role",-12}");
            Console.WriteLine(new string('-', 75));
            foreach (var user in users)
                Console.WriteLine($"  {user.Id,-5} {user.Username,-20} {user.Email,-35} {user.Role,-12}");
        });
    }

    private void FindUserByEmailInteractive()
    {
        var email = Helpers.ReadString("Email: ");
        Helpers.TryExecute(() =>
        {
            var user = _userService.GetUserByEmail(email);
            Console.WriteLine($"\n  Id       : {user.Id}");
            Console.WriteLine($"  Username : {user.Username}");
            Console.WriteLine($"  Email    : {user.Email}");
            Console.WriteLine($"  Role     : {user.Role}");

            if (user.Adoptions != null && user.Adoptions.Count > 0)
            {
                Console.WriteLine($"\n  Adoptions ({user.Adoptions.Count}):");
                foreach (var a in user.Adoptions)
                    Console.WriteLine($"    - [{a.id}] {a.Animal?.Name} on {a.AdoptedAt:yyyy-MM-dd}");
            }
        });
    }

    private void UpdateUserInteractive(UserDto currentUser)
    {
        var email = Helpers.ReadString("Existing user email: ");
        var updateDto = new UpdateUserDto
        {
            Username = Helpers.ReadOptionalString("New username (press Enter to keep): "),
            Email = Helpers.ReadOptionalString("New email (press Enter to keep): "),
            RoleId = Helpers.ParseOptionalRoleId()
        };

        Helpers.TryExecute(() => _userService.UpdateUser(email, updateDto, currentUser.Username), "User updated successfully.");
    }

    private void DeleteUserInteractive(UserDto currentUser)
    {
        var email = Helpers.ReadString("Email to delete: ");
        Console.Write($"Confirm delete '{email}'? (y/N): ");
        if (Console.ReadLine()?.Trim().ToLowerInvariant() != "y")
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

        // Admins can adopt on behalf of another user
        if (_authService.CanManage(currentUser))
        {
            Console.Write("Adopt as another user? (y/N): ");
            if (Console.ReadLine()?.Trim().ToLowerInvariant() == "y")
            {
                var adopterEmail = Helpers.ReadString("Adopter email: ");
                adopterId = _userService.GetUserByEmail(adopterEmail).Id;
            }
        }
        if(_authService.CanDo(currentUser))
        {
            var adopterEmail = Helpers.ReadString("Adopter email: ");
                adopterId = _userService.GetUserByEmail(adopterEmail).Id;
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
                Console.WriteLine("\nNo adoptions found.");
                return;
            }

            Console.WriteLine($"\nFound {adoptions.Count} adoption(s):\n");
            foreach (var adoption in adoptions)
                Helpers.PrintAdoption(adoption);
        });
    }

    private void ViewAdoptionByIdInteractive()
    {
        var id = Helpers.ReadInt("Adoption Id: ");
        Helpers.TryExecute(() =>
        {
            Console.WriteLine();
            Helpers.PrintAdoption(_adoptionService.GetAdoptionById(id));
        });
    }

    private void UpdateAdoptionInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Adoption Id: ");
        var dto = new AnimalShelter.src.Shared.Dto.Adoption.UpdateAdoptionDto
        {
            UserId = ParseOptionalUserIdFromEmail("New adopter email (press Enter to keep): "),
            AnimalId = Helpers.ParseOptionalInt("New animal id (press Enter to keep): "),
            AdoptedAt = Helpers.ReadOptionalDateTime("New adopted date (press Enter to keep): ")
        };

        Helpers.TryExecute(() => _adoptionService.UpdateAdoption(id, dto, currentUser.Username), "Adoption updated.");
    }

    private void DeleteAdoptionInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Adoption Id: ");
        Console.Write($"Confirm delete adoption {id}? (y/N): ");
        if (Console.ReadLine()?.Trim().ToLowerInvariant() != "y")
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        Helpers.TryExecute(() => _adoptionService.DeleteAdoption(id, currentUser.Username), "Adoption deleted.");
    }

    
    private void AddCareNoteInteractive(UserDto currentUser)
    {
        Console.WriteLine("\n--- Add Care Note ---");
        var dto = new AnimalShelter.src.Shared.Dto.CareNoteDtos.AddCareNoteDto
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
        var dto = new AnimalShelter.src.Shared.Dto.CareNoteDtos.UpdateCareNoteDto
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
        if (Console.ReadLine()?.Trim().ToLowerInvariant() != "y")
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        Helpers.TryExecute(() => _careNoteService.DeleteNote(id), "Care note deleted.");
    }

    
    private void AddVaccineInteractive(UserDto currentUser)
    {
        Console.WriteLine("\n--- Add Vaccine ---");
        var dto = new AnimalShelter.src.Shared.Dto.Vaccine.AddVaccineDto
        {
            VaccineName = Helpers.ReadString("Vaccine name: "),
            VaccineDescription = Helpers.ReadOptionalString("Description (optional, press Enter to skip): ") ?? string.Empty,
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
                Console.WriteLine("\nNo vaccines found.");
                return;
            }

            Console.WriteLine($"\nFound {vaccines.Count} vaccine(s):\n");
            foreach (var vaccine in vaccines)
                Helpers.PrintVaccine(vaccine);
        });
    }

    private void ViewVaccineByIdInteractive()
    {
        var id = Helpers.ReadInt("Vaccine Id: ");
        Helpers.TryExecute(() =>
        {
            Console.WriteLine();
            Helpers.PrintVaccine(_vaccineService.GetVaccineById(id));
        });
    }

    private void UpdateVaccineInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Vaccine Id: ");
        var dto = new AnimalShelter.src.Shared.Dto.Vaccine.UpdateVaccineDto
        {
            VaccineName = Helpers.ReadString("Vaccine name: "),
            VaccineDescription = Helpers.ReadOptionalString("Description (optional, press Enter to skip): ") ?? string.Empty,
            AnimalId = Helpers.ReadInt("Animal Id: ")
        };

        Helpers.TryExecute(() => _vaccineService.UpdateVaccine(id, dto, currentUser.Username), "Vaccine updated.");
    }

    private void DeleteVaccineInteractive(UserDto currentUser)
    {
        var id = Helpers.ReadInt("Vaccine Id: ");
        Console.Write($"Confirm delete vaccine {id}? (y/N): ");
        if (Console.ReadLine()?.Trim().ToLowerInvariant() != "y")
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        Helpers.TryExecute(() => _vaccineService.DeleteVaccineById(id, currentUser.Username), "Vaccine deleted.");
    }

    
    private void PrintProfile(UserDto currentUser)
    {
        try
        {
            var profile = _userService.GetUserByEmail(currentUser.Email);
            Helpers.PrintUserProfile(profile);
        }
        catch (AppException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    
    private int? ParseOptionalUserIdFromEmail(string prompt)
    {
        var email = Helpers.ReadOptionalString(prompt);
        if (string.IsNullOrWhiteSpace(email))
            return null;

        try
        {
            return _userService.GetUserByEmail(email).Id;
        }
        catch (AppException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

}