using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Interfaces
{
    public interface IAdoptionService
    {
        void AdoptAnimal(int animalId, int adopterId);
    }
}
