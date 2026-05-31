using System;

namespace AnimalShelter.src.Shared.CustomException
{
    public class AnimalAlreadyAdoptedException : AppException
    {
        public AnimalAlreadyAdoptedException(int animalId, string animalName)
            : base($"Animal '{animalName}' with ID {animalId} is already adopted.")
        {
        }
    }
}