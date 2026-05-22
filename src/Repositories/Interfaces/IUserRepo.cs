using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Repositories.Interfaces
{
    public interface IUserRepo
    {
        void AddUser(CreateUserDto UserDto);

        List<UserDto> GetAllUsers();
        UserDto GetUsers(GetUserDto getUser);

        void DeleteUser(GetUserDto user);

        void UpdateUserName(GetUserDto GetUser,UpdateUserDto UpdateUserName,UserDto CurrentUser);
        

    }
}
