using System;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.src.Services.Interfaces;
using AnimalShelter.Shared;

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
        Console.WriteLine("\n=== Login ===");
        var email = Helpers.ReadString("Email (blank to exit): ");
        if (string.IsNullOrWhiteSpace(email))
            return null;

        var password = Helpers.ReadPassword();

        try
        {
            return _authService.Login(new AnimalShelter.Dto.LoginDto { Email = email, Password = password });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login failed: {ex.Message}");
            return null;
        }
    }

}
