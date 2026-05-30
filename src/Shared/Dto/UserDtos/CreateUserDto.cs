using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.src.Shared.Dto.UserDtos
{
    
    public class CreateUserDto
    {
        
        public string UserName { get; set; } = string.Empty;
        [EmailAddress]
        
        public string UserEmail { get; set; } = string.Empty;

        
        public string UserPassword { get; set; } = string.Empty;
    }
}
