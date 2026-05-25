using System;

namespace AnimalShelter.CustomException
{
    public class AdopterNotFoundException : Exception
    {
        public AdopterNotFoundException()
            : base($"adopter not found)")
        {
        }

        
    }
}