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
        void AddUser(User user);

        List<User> GetAllUsers();

        User GetUserByEmail(string email);

        public void DeleteUser(User user);

        public void SaveChange();

    }
}
