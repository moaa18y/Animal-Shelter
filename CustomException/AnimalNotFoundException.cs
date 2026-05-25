using System;

namespace AnimalShelter.CustomException
{
    public class AnimalNotFoundException : Exception
    {
        public AnimalNotFoundException()
            : base($"Animal was not found.")
        {
        }
    }
}