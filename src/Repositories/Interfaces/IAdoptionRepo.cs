using Animal_Shelter_V2.src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Repositories.Interfaces
{
    public interface IAdoptionRepo
    {
        public void AddAdoption(Adoption adoption);
        public Adoption GetById(int id);
        public void RemoveAdoption(int id);
        public void UpdateAdoption(Adoption adoption);
    }
}
