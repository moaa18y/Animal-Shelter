using AnimalShelter.src.Shared.CustomException;
using AnimalShelter.src.Repositories.Implementations;
using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.src.Services.Interfaces;
using AnimalShelter.src.Shared.Dto.Vaccine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace AnimalShelter.src.Services.Implementation
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepo _vaccineRepo;

        public VaccineService(IVaccineRepo vaccineRepo   )
        {
            _vaccineRepo = vaccineRepo;
        }

        public void AddVaccine(AddVaccineDto vaccineDto, string CreatedBy)
        {
            var vaccine = new Vaccine
            {
                VaccineName=vaccineDto.VaccineName,
                VaccineDescription=vaccineDto.VaccineDescription,
                AnimalId=vaccineDto.AnimalId,
                        
            };
            vaccine.CreatedBy = CreatedBy;

            _vaccineRepo.AddVaccine(vaccine);
            
            _vaccineRepo.SaveChange();

        }

        public void DeleteVaccineById(int id, string DeletedBy)
        {
            var vaccine=_vaccineRepo.GetVaccineById(id);

            if(vaccine is null)
            {
                throw new VaccineException("Vaccine Not Found");
            }
            
            vaccine.DeletedBy=DeletedBy;
            vaccine.DeletedAt=DateTime.Now;
            vaccine.IsDeleted=true;
           
            _vaccineRepo.SaveChange();

        }

        public List<GetVaccineDto> GetAllVaccines()
        {
            var vaccines=_vaccineRepo.GetAllVaccines();
            
            return vaccines.Select(v => new GetVaccineDto
            {
                Id=v.VaccineId,
                VaccineName = v.VaccineName,
                VaccineDate = v.VaccineDate,
            }).ToList();
           
        }

        public GetVaccineDto GetVaccineById(int id)
        {
            var vaccine = _vaccineRepo.GetVaccineById(id);
            if (vaccine is null)
            {
                throw new VaccineException("Vaccine Not Found");
            }

            return  new GetVaccineDto
            {
                Id = vaccine.VaccineId,
                VaccineName = vaccine.VaccineName,
                VaccineDate = vaccine.VaccineDate
            };
        }

        public void UpdateVaccine(int id, UpdateVaccineDto UpdateVaccine, string UpdatedBy)
        {
            var vaccine = _vaccineRepo.GetVaccineById(id);

            if (vaccine is null)
                throw new VaccineException("Vaccine Not Found");
            
            if (!string.IsNullOrEmpty(UpdateVaccine.VaccineName))
                vaccine.VaccineName = UpdateVaccine.VaccineName;
            if (!string.IsNullOrEmpty(UpdateVaccine.VaccineDescription))
                vaccine.VaccineDescription = UpdateVaccine.VaccineDescription;

            vaccine.UpdatedAt=DateTime.Now;
            vaccine.UpdatedBy=UpdatedBy;
            _vaccineRepo.SaveChange();

        }
    }
}
