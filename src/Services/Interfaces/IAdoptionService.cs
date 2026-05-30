using System;
using System.Collections.Generic;
using System.Text;
using AnimalShelter.src.Shared.Dto.Adoption;

namespace AnimalShelter.src.Services.Interfaces
{
    public interface IAdoptionService
    {
        void AdoptAnimal(int animalId, int adopterId);
        AdoptionsDto GetAdoptionById(int id);
        List<AdoptionsDto> GetAllAdoptions();
        void UpdateAdoption(int id, UpdateAdoptionDto adoptionDto, string updatedBy);
        void DeleteAdoption(int id, string deletedBy);
    }
}
