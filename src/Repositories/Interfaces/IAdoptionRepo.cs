using AnimalShelter.src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Repositories.Interfaces
{
    public interface IAdoptionRepo
    {
         void AddAdoption(Adoption adoption);
         Adoption? GetById(int id);
         System.Collections.Generic.List<Adoption> GetAllAdoptions();
         void RemoveAdoption(int id);
         void UpdateAdoption(Adoption adoption);
    }
}
