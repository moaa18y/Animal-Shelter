using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.src.Shared.Dto.UserDtos
{
    public class GetUserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public EnumRole Role { get; set; }
    }
}
