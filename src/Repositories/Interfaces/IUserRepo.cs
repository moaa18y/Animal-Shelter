using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Repositories.Interfaces
{
    public interface IUserRepo
    {
        void AddUser(User user);

        List<User> GetAllUsers();
         User GetUserById(int id);

        User GetUserByEmail(string email);

        User GetUserByEmailReadOnly(string email);

         void DeleteUser(User user, string DeletedBy);


         void UpdateUser(User user, UpdateUserDto UpdateUser, string updatedBy);
        void SaveChange();

    }
}
