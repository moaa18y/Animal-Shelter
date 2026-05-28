
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Interfaces
{
    public interface IAuthorizationService
    {
         bool CanManage(UserDto userDto);//Only for Admin

         bool CanDo(UserDto userDto);//For User and Employee 
         bool CanControll(UserDto userDto); //For Employee
    }
}
