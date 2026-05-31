using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.CustomException
{
    public class InvalidPasswordException : AppException
    {
        public InvalidPasswordException() : base("Invalid password")
        {
        }
    }
}
