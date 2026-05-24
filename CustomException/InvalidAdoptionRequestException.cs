using System;

namespace AnimalShelter.CustomException
{
    public class InvalidAdoptionRequestException : Exception
    {
        public InvalidAdoptionRequestException(string message)
            : base(message)
        {
        }
    }
}