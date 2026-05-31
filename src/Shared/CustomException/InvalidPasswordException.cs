using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.CustomException
{
    internal class InvalidPasswordException : AppException
    {
        public InvalidPasswordException() : base("Invalid password")
        {
        }
    }
}
