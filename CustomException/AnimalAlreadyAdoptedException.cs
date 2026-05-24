using System;

namespace AnimalShelter.CustomException
{
    public class AnimalAlreadyAdoptedException : Exception
    {
        public AnimalAlreadyAdoptedException(int animalId, string animalName)
            : base($"Animal '{animalName}' with ID {animalId} is already adopted.")
        {
        }
    }
}