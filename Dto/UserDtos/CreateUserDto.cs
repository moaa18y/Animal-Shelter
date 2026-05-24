using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Dto
{
    public class CreateUserDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = string.Empty;   

        [Required]
        public string UserPassword { get; set; } = string.Empty;
    }
}
