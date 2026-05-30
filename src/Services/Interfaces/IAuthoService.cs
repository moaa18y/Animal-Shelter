using AnimalShelter.src.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AnimalShelter.src.Shared.Dto.AuthoDtos;

namespace AnimalShelter.src.Services.Interfaces
{
     public interface IAuthoService
     {
          UserDto Login(LoginDto loginDto);
     }
}

