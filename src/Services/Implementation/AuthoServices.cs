using Animal_Shelter_V2.src.Models;
using AnimalShelter.CustomException;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AuthoServices : IAutho
    {
    private readonly List<User> _users;

   
    public AuthoServices(List<User> users)
    {
        _users = users;
    }

    UserDto  IAutho.Login(LoginDto loginDto)
    {
        var user=_users.FirstOrDefault(u=> u.UserEmail==loginDto.Email);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
         var hash = new PasswordHasher<User>();

        var result = hash.VerifyHashedPassword(user, user.UserPassword, loginDto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new InvalidPasswordException();
        }

        Console.WriteLine($"Login successful {user.UserName}");
        return new UserDto
        {
            Username = user.UserName,
            Role = user.Role.RoleName
        };
    }
}

