using AnimalShelter.src.Models;
using AnimalShelter.Dto;
using System;
using System.Collections.Generic;
using System.Text;


    public class UserDto
    {
         public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public EnumRole Role { get; set; }

        public  List<AdoptionsDto> Adoptions { get; set; }

    }

