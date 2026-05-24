using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.CustomException
{
    public class UserAlreadyExist :Exception
    {
        public UserAlreadyExist() : base("Email Already Used ") { }
    }
}
