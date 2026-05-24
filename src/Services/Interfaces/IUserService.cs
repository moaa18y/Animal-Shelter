using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Interfaces
{
    public interface IUserService
    {

        void AddUser(CreateUserDto UserDto, string CreatedBy);

        List<UserDto> GetAllUsers();

        UserDto GetUserByEmail(string email);

        public void DeleteUser(string email, string DeletedBy);

        
        public void UpdateUser(string email, UpdateUserDto UpdateUser, string updatedBy);

    }
}
