using AnimalShelter.src.Models;
using AnimalShelter.CustomException;
using AnimalShelter.DbForMigration;
using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.Dto;
using AnimalShelter.src.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.src.Services.Implementation
{
    public class AuthoServices : IAuthoService
    {
        private readonly IUserRepo _usersrepo;

        public AuthoServices(IUserRepo usersrepo)
        {
            _usersrepo = usersrepo;
        }

        public UserDto Login(LoginDto loginDto)
        {
            var user = _usersrepo.GetUserByEmail(loginDto.Email);
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
                Email = user.UserEmail,
                Role = user.Role.RoleName
            };
        }
    }
}

