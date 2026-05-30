using AnimalShelter.src.Shared.Dto.UserDtos;
using AnimalShelter.src.Shared.Dtos;
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

         void DeleteUser(string email, string DeletedBy);

       
         void UpdateUser(string email, UpdateUserDto UpdateUser, string updatedBy);

    }
}
