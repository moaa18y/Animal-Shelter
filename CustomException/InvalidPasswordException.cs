using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.CustomException
{
    internal class InvalidPasswordException:Exception
    {
        public InvalidPasswordException() : base("Invalid password")
        {
        }
    }
}
