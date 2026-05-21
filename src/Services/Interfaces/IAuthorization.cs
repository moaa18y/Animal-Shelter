
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Interfaces
{
    public interface IAuthorization
    {
        protected bool CanManage(UserDto userDto);//Only for Admin

        protected bool CanDo(UserDto userDto);//For User and Employee 
        protected bool CanControll(UserDto userDto); //For Employee
    }
}
