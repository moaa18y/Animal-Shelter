using AnimalShelter.CustomException;
using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.src.Repositories.Implementations;
using AnimalShelter.src.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserRepo _userRepo;

        public UserService(UserRepo userRepo)
        {
            userRepo = _userRepo;
        }
        public void AddUser(CreateUserDto UserDto)
        {
            if (_userRepo.GetUserByEmail(UserDto.UserEmail) is not null)
                throw new UserAlreadyExist();

            var hasher = new PasswordHasher<User>();

            var user = new User
            {
                UserName = UserDto.UserName,
                UserEmail = UserDto.UserEmail
            };

            user.UserPassword = hasher.HashPassword(user, UserDto.UserPassword);

            _userRepo.AddUser(user);
            _userRepo.SaveChange();


        }

        public void DeleteUser(string email)
        {
            var user = _userRepo.GetUserByEmail(email);
            if(user is null)
            {
                throw new UserNotFoundException();
            }

            throw new NotImplementedException();
        }

        public List<UserDto> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserByEmail(string email)
        {

            throw new NotImplementedException();
        }

        public void UpdateUser(string email, UpdateUserDto UpdateUser, string updatedBy)
        {
            var user = _userRepo.GetUserByEmail( email);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            if (!string.IsNullOrEmpty(UpdateUser.Username))
                user.UserName = UpdateUser.Username;

            if (!string.IsNullOrEmpty(UpdateUser.Email))
                user.UserEmail = UpdateUser.Email;

            if (UpdateUser.RoleId.HasValue)
                user.RoleId = UpdateUser.RoleId.Value;


            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = updatedBy;

            _userRepo.SaveChange();

            
        }

        
    }
}
