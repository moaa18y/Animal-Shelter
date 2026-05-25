using Animal_Shelter_V2.src.Models;
using AnimalShelter.CustomException;
using AnimalShelter.DbForMigration;
using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.src.Repositories.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDBContext _dbContext;

        public UserRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User  NewUser)
        {
            _dbContext.Users.Add(NewUser);
            

        }
        



       public List<User> GetAllUsers()
        {

            return _dbContext.Users
            .Include(u => u.Role)
            .Include(u => u.Adoptions)
            .ThenInclude(a => a.Animal)
                .ThenInclude(an => an.Vaccines)
                .AsNoTracking().ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users
                .Include(u => u.Role)
                .Include(u => u.Adoptions)
                    .ThenInclude(a => a.Animal)
                        .ThenInclude(an => an.Vaccines)
                .FirstOrDefault(u => u.UserId == id);
        }

        

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users
                .Include(u => u.Role)
                .Include(u => u.Adoptions)
                    .ThenInclude(a => a.Animal)
                        .ThenInclude(an => an.Vaccines)
                .FirstOrDefault(u => u.UserEmail == email);
        }


        public User GetUserByEmailReadOnly(string email)
        {
            return _dbContext.Users
                .Include(u => u.Role)
                .Include(u => u.Adoptions)
                    .ThenInclude(a => a.Animal)
                        .ThenInclude(an => an.Vaccines).AsNoTracking()
                .FirstOrDefault(u => u.UserEmail == email);

        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

    }
}
