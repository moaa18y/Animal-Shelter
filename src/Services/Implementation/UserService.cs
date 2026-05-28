using AnimalShelter.CustomException;
using AnimalShelter.Dto;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.src.Repositories.Implementations;
using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.src.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.src.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public void AddUser(CreateUserDto UserDto, string CreatedBy)
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
            user.CreatedBy = CreatedBy;
            _userRepo.AddUser(user);
            _userRepo.SaveChange();


        }

        public void DeleteUser(string email, string DeletedBy)
        {
            var user = _userRepo.GetUserByEmail(email);
            if(user is null)
            {
                throw new UserNotFoundException();
            }
            
            _userRepo.DeleteUser(user, DeletedBy);
            _userRepo.SaveChange();

        }

        public List<UserDto> GetAllUsers()
        {

            var users = _userRepo.GetAllUsers();
            return users.Select(u => new UserDto
            {
                Id = u.UserId,
                Username = u.UserName,
                Email = u.UserEmail,
                Role=u.Role.RoleName,
                Adoptions= u.Adoptions.Select(a=> new AdoptionsDto
                {
                    id = a.AdoptionId,
                    AdoptedAt=a.AdoptedAt,
                    Animal=new GetAnimalDto
                    {
                        Id=a.AnimalId,
                        Name=a.Animal.Name,
                        Age=a.Animal.Age,
                        Species=a.Animal.Species,
                        Status=a.Animal.Status,
                        Breed=a.Animal.Breed,
                        Size=a.Animal.Size,
                        Color=a.Animal.Color,
                        IsIndoor=a.Animal.IsIndoor,
                        CanFly=a.Animal.CanFly,
                        AnimalType=a.Animal.AnimalType,
                        IsNocturnal =a.Animal.IsNocturnal,
                        Vaccines=a.Animal.Vaccines.Select(v=>new GetVaccineDto
                        {
                            Id=v.VaccineId,
                            VaccineName=v.VaccineName,
                            VaccineDate=v.VaccineDate

                        }).ToList(),
                        careNotes=a.Animal.CareNotes.Select(c=>new GetCareNoteDto
                        {  id=c.Id,
                           Title=c.Title,
                           Description=c.Description

                        }).ToList()
                        
                    }
                }).ToList()
               
            }).ToList();

        }


        public UserDto GetUserByEmail(string email)
        {

            var user = _userRepo.GetUserByEmailReadOnly(email);
            if(user is null)
            {
                throw new UserNotFoundException();
            }
            return  new UserDto
            {
                Id = user.UserId,
                Username = user.UserName,
                Email = user.UserEmail,
                Role = user.Role.RoleName,
                Adoptions = user.Adoptions.Select(a => new AdoptionsDto
                {
                    id = a.AdoptionId,
                    AdoptedAt = a.AdoptedAt,
                    Animal = new GetAnimalDto
                    {
                        Id = a.AnimalId,
                        Name = a.Animal.Name,
                        Age = a.Animal.Age,
                        Species = a.Animal.Species,
                        Status = a.Animal.Status,
                        Breed = a.Animal.Breed,
                        Size = a.Animal.Size,
                        Color = a.Animal.Color,
                        IsIndoor = a.Animal.IsIndoor,
                        CanFly = a.Animal.CanFly,
                        AnimalType = a.Animal.AnimalType,
                        IsNocturnal = a.Animal.IsNocturnal,
                        Vaccines = a.Animal.Vaccines.Select(v => new GetVaccineDto
                        {
                            Id = v.VaccineId,
                            VaccineName = v.VaccineName,
                            VaccineDate = v.VaccineDate

                        }).ToList(),
                        careNotes = a.Animal.CareNotes.Select(c => new GetCareNoteDto
                        {
                            id = c.Id,
                            Title = c.Title,
                            Description = c.Description

                        }).ToList()
                    }
                }).ToList()

            };
        }

        public void UpdateUser(string email, UpdateUserDto UpdateUser, string updatedBy)
        {
            var user = _userRepo.GetUserByEmail( email);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            _userRepo.UpdateUser(user, UpdateUser, updatedBy);

            _userRepo.SaveChange();

            
        }

        
    }
}
