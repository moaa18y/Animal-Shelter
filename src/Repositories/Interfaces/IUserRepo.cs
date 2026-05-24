using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using Animal_Shelter_V2.src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Repositories.Interfaces
{
    public interface IUserRepo
    {
        void AddUser(CreateUserDto UserDto);

        User FindByEmail(string email);

        List<UserDto> GetAllUsers();
        UserDto GetUsers(GetUserDto getUser);

        void DeleteUser(GetUserDto user);

        void UpdateUserName(GetUserDto GetUser,UpdateUserDto UpdateUserName,UserDto CurrentUser);
        

    }
}
