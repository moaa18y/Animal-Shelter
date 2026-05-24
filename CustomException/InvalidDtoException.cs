using System;

namespace AnimalShelter.CustomException
{
    public class InvalidDtoException : Exception
    {
        public InvalidDtoException(string message)
            : base(message)
        {
        }
    }
}