
using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.CustomException;
using AnimalShelter.src.Models;
using AnimalShelter.Dto;
using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.src.Services.Interfaces;

namespace AnimalShelter.src.Services.Implementation
{
    public class Adoptionservice : IAdoptionService
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IAdoptionRepo _adoptionRepo;
        private readonly IUserRepo _userRepo;

        public Adoptionservice(IAnimalRepository animalRepo, IAdoptionRepo adoptionRepo, IUserRepo userRepo)
        {
            _animalRepo = animalRepo ?? throw new RepoNotFoundException(nameof(animalRepo));
            _adoptionRepo = adoptionRepo ?? throw new RepoNotFoundException(nameof(adoptionRepo));
            _userRepo = userRepo ?? throw new RepoNotFoundException(nameof(userRepo));
        }

        public void AdoptAnimal(int animalId, int adopterId)
        {
            var animal = _animalRepo.FindById(animalId);
            if (animal == null)
                throw new AnimalNotFoundException();

            if (animal.Status == EnumAnimalStatus.Adopted)
                throw new AnimalAlreadyAdoptedException(animal.Id, animal.Name);

            var user = _userRepo.GetUserById(adopterId);
            if (user == null)
                throw new AdopterNotFoundException();

            var adoption = new Adoption
            {
                AnimalId = animal.Id,
                Animal = animal,
                UserId = user.UserId,
                User = user,
                CreatedBy = user.UserName,
                AdoptedAt = DateTime.Now
            };

            animal.Status = EnumAnimalStatus.Adopted;
            animal.Adoption = adoption;

            if (user.Adoptions == null)
                user.Adoptions = new List<Adoption>();

            user.Adoptions.Add(adoption);

            _adoptionRepo.AddAdoption(adoption);
            _animalRepo.UpdateStatus(animalId, EnumAnimalStatus.Adopted);
        }

        public AdoptionsDto GetAdoptionById(int id)
        {
            var adoption = _adoptionRepo.GetById(id);
            if (adoption == null)
                throw new Exception("Adoption not found.");

            return MapAdoption(adoption);
        }

        public List<AdoptionsDto> GetAllAdoptions()
        {
            return _adoptionRepo.GetAllAdoptions()
                .Select(MapAdoption)
                .ToList();
        }

        public void UpdateAdoption(int id, UpdateAdoptionDto adoptionDto, string updatedBy)
        {
            var adoption = _adoptionRepo.GetById(id);
            if (adoption == null)
                throw new Exception("Adoption not found.");

            var oldAnimalId = adoption.AnimalId;

            if (adoptionDto.UserId.HasValue)
            {
                var user = _userRepo.GetUserById(adoptionDto.UserId.Value);
                if (user == null)
                    throw new AdopterNotFoundException();

                adoption.UserId = user.UserId;
                adoption.User = user;
                adoption.CreatedBy = updatedBy;
            }

            if (adoptionDto.AnimalId.HasValue)
            {
                var newAnimal = _animalRepo.FindById(adoptionDto.AnimalId.Value);
                if (newAnimal == null)
                    throw new AnimalNotFoundException();

                if (newAnimal.Status == EnumAnimalStatus.Adopted && newAnimal.Id != oldAnimalId)
                    throw new AnimalAlreadyAdoptedException(newAnimal.Id, newAnimal.Name);

                adoption.AnimalId = newAnimal.Id;
                adoption.Animal = newAnimal;
                newAnimal.Status = EnumAnimalStatus.Adopted;
                _animalRepo.UpdateStatus(newAnimal.Id, EnumAnimalStatus.Adopted);

                if (oldAnimalId != newAnimal.Id)
                    _animalRepo.UpdateStatus(oldAnimalId, EnumAnimalStatus.Available);
            }

            if (adoptionDto.AdoptedAt.HasValue)
                adoption.AdoptedAt = adoptionDto.AdoptedAt.Value;

            _adoptionRepo.UpdateAdoption(adoption);
        }

        public void DeleteAdoption(int id, string deletedBy)
        {
            var adoption = _adoptionRepo.GetById(id);
            if (adoption == null)
                throw new Exception("Adoption not found.");

            var animal = _animalRepo.FindById(adoption.AnimalId);
            if (animal != null)
                _animalRepo.UpdateStatus(animal.Id, EnumAnimalStatus.Available);

            _adoptionRepo.RemoveAdoption(id);
        }

        private static AdoptionsDto MapAdoption(Adoption adoption)
        {
            return new AdoptionsDto
            {
                id = adoption.AdoptionId,
                AdoptedAt = adoption.AdoptedAt,
                Animal = adoption.Animal == null ? null : new GetAnimalDto
                {
                    Id = adoption.Animal.Id,
                    Name = adoption.Animal.Name,
                    Age = adoption.Animal.Age,
                    Species = adoption.Animal.Species,
                    Status = adoption.Animal.Status,
                    Breed = adoption.Animal.Breed,
                    Size = adoption.Animal.Size,
                    Color = adoption.Animal.Color,
                    IsIndoor = adoption.Animal.IsIndoor,
                    CanFly = adoption.Animal.CanFly,
                    AnimalType = adoption.Animal.AnimalType,
                    IsNocturnal = adoption.Animal.IsNocturnal
                }
            };
        }
    }
}