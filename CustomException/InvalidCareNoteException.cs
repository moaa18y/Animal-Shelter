using System;

namespace AnimalShelter.CustomException
{
    public class InvalidCareNoteException : Exception
    {
        public InvalidCareNoteException(string message)
            : base(message)
        {
        }
    }
}