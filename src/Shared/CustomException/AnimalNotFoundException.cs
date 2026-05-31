using System;

namespace AnimalShelter.src.Shared.CustomException
{
    public class AnimalNotFoundException : AppException
    {
        public AnimalNotFoundException()
            : base($"Animal was not found.")
        {
        }
    }
}