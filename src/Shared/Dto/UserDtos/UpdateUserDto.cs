using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.Dto.UserDtos
{
    public class UpdateUserDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
    }
}
