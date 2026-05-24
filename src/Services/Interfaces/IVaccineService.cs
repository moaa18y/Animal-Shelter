using AnimalShelter.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Interfaces
{
    public interface IVaccineService
    {
        void AddVaccine(AddVaccineDto vaccineDto, string CreatedBy);
        GetVaccineDto GetVaccineById(int id);

        List<GetVaccineDto> GetAllVaccines();

        void UpdateVaccine(int id, UpdateVaccineDto UpdateVaccine,string UpdatedBy);

        void DeleteVaccineById(int id, string DeletedBy);
    }
}
