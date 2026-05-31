using System;
using AnimalShelter.src.Shared.Dto.UserDtos;
using AnimalShelter.src.Services.Interfaces;
using AnimalShelter.Shared;
using AnimalShelter.src.Shared.CustomException;
using AnimalShelter.Shared.Menus;

#nullable enable

public class AuthorizationController
{
    private readonly IAuthoService _authService;
    private readonly UsersController _usersController;

    public AuthorizationController(
        IAuthoService authService,
        UsersController usersController)
    {
        _authService = authService;
        _usersController = usersController;
    }

    public void Run()
    {
        while (true)
        {
            var user = LoginFlow();
            if (user == null)
                return;

            _usersController.ShowMenu(user);
        }
    }

    private UserDto? LoginFlow()
    {
        while (true)
        {
            AppMenus.PrintLoginHeader();
            var email = Helpers.ReadString("Email (blank to exit): ");
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var password = Helpers.ReadPassword();

            try
            {
                return _authService.Login(new AnimalShelter.src.Shared.Dto.AuthoDtos.LoginDto { Email = email, Password = password });
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Login failed: User not found with this email address.");
            }
            catch (InvalidPasswordException)
            {
                Console.WriteLine("Login failed: Invalid password. Please try again.");
            }
        }
    }

}
