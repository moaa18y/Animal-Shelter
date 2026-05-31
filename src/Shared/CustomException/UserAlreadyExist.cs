using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.CustomException
{
    public class UserAlreadyExist : AppException
    {
        public UserAlreadyExist() : base("Email Already Used ") { }
    }
}
