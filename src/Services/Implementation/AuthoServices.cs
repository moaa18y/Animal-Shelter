using AnimalShelter.src.Models;
using AnimalShelter.CustomException;
using AnimalShelter.DbForMigration;
using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.Dto;
using AnimalShelter.src.Services.Interfaces;
using BCrypt.Net;
using System;

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
            var user = _usersrepo.GetAllUserInfoByEmail(loginDto.Email);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            
            bool isValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.UserPassword);

            if (!isValid)
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