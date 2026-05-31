using System;

namespace AnimalShelter.src.Shared.CustomException
{
    public class AdopterNotFoundException : AppException
    {
        public AdopterNotFoundException()
            : base($"adopter not found)")
        {
        }

        
    }
}