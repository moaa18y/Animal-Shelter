using Animal_Shelter_V2.src.Models;

using AnimalShelter.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Implementation
{
    public class Authorization : IAuthorization
    {

        public bool CanDo(UserDto userDto)
        {
            return (userDto.Role == EnumRole.User || userDto.Role == EnumRole.Employee);
            
            
        }

        public bool CanManage(UserDto userDto)
        {
            return (userDto.Role == EnumRole.Admin);
        }

        public bool CanControll(UserDto userDto)
        {
            return (userDto.Role == EnumRole.Employee);
        }
    }
}
