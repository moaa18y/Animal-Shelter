
using AnimalShelter.CustomException;
using AnimalShelter.src.Shared.Dto.AnimalDtos;
using AnimalShelter.src.Shared.Dto.Vaccine;
using AnimalShelter.src.Shared.Dto.CareNoteDtos;
using AnimalShelter.src.Models;
using AnimalShelter.src.Repositories.Implementations;
using AnimalShelter.src.Repositories.Interfaces;
using Azure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;

namespace AnimalShelter.src.Services.Implementation
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repo;
        private readonly IUserRepo _userRepo;

        public AnimalService(IAnimalRepository repo, IUserRepo userRepo)
        {
            _repo = repo ?? throw new RepoNotFoundException(nameof(repo));
            _userRepo = userRepo ?? throw new RepoNotFoundException(nameof(userRepo));
        }

        public void AddAnimal(AddAnimalDto animalDto, string createdBy)
        {
          
            var animal = new Animal
            {
                Name = animalDto.Name,
                Age = animalDto.Age,
                Species = animalDto.Species,
                Breed = animalDto.Breed,
                Size = animalDto.Size,
                Color = animalDto.Color,
                IsIndoor = animalDto.IsIndoor,
                CanFly = animalDto.CanFly,
                AnimalType = animalDto.AnimalType,
                IsNocturnal = animalDto.IsNocturnal,
                CreatedBy = createdBy,
                UpdatedAt = DateTime.Now
            };

            _repo.Add(animal);
        }

        public bool RemoveAnimal(int id)
        {
            var animal = _repo.FindById(id);

            if (animal == null)
                throw new AnimalNotFoundException();

            return _repo.Remove(id);
        }

        public GetAnimalDto GetAnimal(int id)
        {
            var animalM = _repo.FindByIdReadOnly(id);

            if (animalM == null)
                throw new AnimalNotFoundException();
            
            return new GetAnimalDto
            {
                Id = animalM.Id,
                Name = animalM.Name,
                Age = animalM.Age,
                Species = animalM.Species,
                Status = animalM.Status,
                Breed = animalM.Breed,
                Size = animalM.Size,
                Color = animalM.Color,
                IsIndoor = animalM.IsIndoor,
                CanFly = animalM.CanFly,
                AnimalType = animalM.AnimalType,
                IsNocturnal = animalM.IsNocturnal,
                Vaccines = (animalM.Vaccines ?? new List<Vaccine>()).Select(v => new GetVaccineDto
                {
                    Id = v.VaccineId,
                    VaccineName = v.VaccineName,
                    VaccineDate = v.VaccineDate

                }).ToList(),
                careNotes = (animalM.CareNotes ?? new List<CareNote>()).Select(c => new GetCareNoteDto
                {
                    id = c.Id,
                    Title = c.Title,
                    Description = c.Description

                }).ToList()
            }; 
        }

        public List<GetAnimalDto> GetAllAnimals()
        {
            var animalM = _repo.GetAll();
            return animalM.Select(a => new GetAnimalDto
            {
                Id = a.Id,
                Name = a.Name,
                Age = a.Age,
                Species = a.Species,
                Status = a.Status,
                Breed = a.Breed,
                Size = a.Size,
                Color = a.Color,
                IsIndoor = a.IsIndoor,
                CanFly = a.CanFly,
                AnimalType = a.AnimalType,
                IsNocturnal = a.IsNocturnal,
                Vaccines = (a.Vaccines ?? new List<Vaccine>()).Select(v => new GetVaccineDto
                {
                    Id = v.VaccineId,
                    VaccineName = v.VaccineName,
                    VaccineDate = v.VaccineDate
                }).ToList(),
                careNotes = (a.CareNotes ?? new List<CareNote>()).Select(c => new GetCareNoteDto
                {
                    id = c.Id,
                    Title = c.Title,
                    Description = c.Description

                }).ToList()
            }).ToList();
        }

        

        public void UpdateStatus(int id, EnumAnimalStatus newStatus)
        {
            var animal = _repo.FindById(id);
            if (animal == null)
                throw new AnimalNotFoundException();

            _repo.UpdateStatus(id, newStatus);
        }
    }
}
