using System;

namespace AnimalShelter.CustomException
{
    public class AnimalNotFoundException : Exception
    {
        public AnimalNotFoundException(int animalId)
            : base($"Animal with ID {animalId} was not found.")
        {
        }
    }
}