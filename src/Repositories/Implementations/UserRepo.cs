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

        public void AddUser(CreateUserDto UserDt)
        {
            var user = new User
            {
                UserName = UserDt.UserName,
                UserEmail = UserDt.UserEmail,
                UserPassword = UserDt.UserPassword
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
           
        }

        public User FindByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserEmail == email);
        }

        public void DeleteUser(GetUserDto Getuser)
        {
            var user=_dbContext.Users.FirstOrDefault(u=> u.UserEmail== Getuser.Email);

            if(user is null)
            {
                throw new UserNotFoundException();
            }
            user.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public List<UserDto> GetAllUsers()
        {
           
            return _dbContext.Users.Select(u=>new UserDto
            {
                Id=u.UserId,
                Username = u.UserName,
                Email = u.UserEmail,
                Role=u.Role.RoleName,
                Adoptions=u.Adoptions.Select(a=>new AdoptionsForUser
                {
                    id=a.Id,
                    AdoptedAt=a.AdoptedAt,
                    Animal=new AllAnimalsAdoptionForUser
                    {
                        id = a.Animal.Id,
                        name=a.Animal.Name,
                        age=a.Animal.Age,
                        Vaccines=a.Animal.Vaccines.Select(v=>new AllVaccinesForEachAnimalAdoptByUser
                        {
                            Id = v.VaccineId,
                            VaccineName=v.VaccineName,
                            VaccineDate=v.VaccineDate
                        }).ToList()
                    }
                }).ToList()
            }).ToList();
        }

        public UserDto GetUsers(GetUserDto getUser)
        {
            var user = _dbContext.Users.Where(u => u.UserEmail == getUser.Email).Select(u => new UserDto
                {
                    Id = u.UserId,
                    Username = u.UserName,
                    Email = u.UserEmail,
                    Role = u.Role.RoleName,
                    Adoptions = u.Adoptions.Select(a => new AdoptionsForUser
                    {
                        id = a.Id,
                        AdoptedAt = a.AdoptedAt,
                        Animal = new AllAnimalsAdoptionForUser
                        {
                            id = a.Animal.Id,
                            name = a.Animal.Name,
                            age = a.Animal.Age,
                            Vaccines = a.Animal.Vaccines.Select(v => new AllVaccinesForEachAnimalAdoptByUser
                            {
                                Id = v.VaccineId,
                                VaccineName = v.VaccineName,
                                VaccineDate = v.VaccineDate
                            }).ToList()
                        }
                    }).ToList()
                }).FirstOrDefault();
            
            if(user is null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }

       

        public void UpdateUser(GetUserDto getUser, UpdateUserDto updateUser, UserDto CurrentUser)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserEmail == getUser.Email);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            if (!string.IsNullOrEmpty(updateUser.Username))
                user.UserName = updateUser.Username;

            if (!string.IsNullOrEmpty(updateUser.Email))
                user.UserEmail = updateUser.Email;

            if (updateUser.RoleId.HasValue)
                user.RoleId = updateUser.RoleId.Value;

            
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = CurrentUser.Username;
            
            _dbContext.SaveChanges();
        }

       
    }
}
