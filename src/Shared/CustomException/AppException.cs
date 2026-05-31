using System;

namespace AnimalShelter.src.Shared.CustomException
{
    public abstract class AppException : Exception
    {
        protected AppException(string message) : base(message)
        {
        }
    }
}