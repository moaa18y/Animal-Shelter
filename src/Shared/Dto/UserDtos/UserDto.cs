using AnimalShelter.src.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AnimalShelter.src.Shared.Dto.Adoption;
using AnimalShelter.src.Shared.Enums;


public class UserDto
    {
         public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public EnumRole Role { get; set; }

        public  List<AdoptionsDto> Adoptions { get; set; }

    }

