using System;

namespace AnimalShelter.src.Shared.CustomException
{
    public class InvalidCareNoteException : AppException
    {
        public InvalidCareNoteException(string message)
            : base(message)
        {
        }
    }
}