using AnimalShelter.src.Models;
using AnimalShelter.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Interfaces
{
     public interface IAuthoService
     {
          UserDto Login(LoginDto loginDto);
     }
}

