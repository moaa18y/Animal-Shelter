using System;

namespace AnimalShelter.src.Shared.CustomException
{
    public class InvalidAdoptionRequestException : AppException
    {
        public InvalidAdoptionRequestException(string message)
            : base(message)
        {
        }
    }
}