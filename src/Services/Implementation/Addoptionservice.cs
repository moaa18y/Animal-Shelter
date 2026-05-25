
using Animal_Shelter.CustomException;
using Animal_Shelter.src.Repositories.Implementations;
using Animal_Shelter_V2.src.Models;
using Animal_Shelter_V2.src.Repositories.Interfaces;
using AnimalShelter.Dto;

using AnimalShelter.CustomException;

using AnimalShelter.src.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Animal_Shelter.src.Services.Implementation
{
    public class Addoptionservice
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IAdoptionRepo _adoptionRepo;
        private readonly IUserRepo _userRepo;
        public Addoptionservice(IAnimalRepository animalRepo, IAdoptionRepo adoptionRepo, IUserRepo userRepo)
        {
            _animalRepo = animalRepo ?? throw new RepoNotFoundException(nameof(animalRepo));
            _adoptionRepo = adoptionRepo ?? throw new RepoNotFoundException(nameof(adoptionRepo));
            _userRepo = userRepo ?? throw new RepoNotFoundException(nameof(userRepo));
        }
        public void AdoptAnimal(int animal_id, int adopter_id)
        {

            var animal = _animalRepo.FindById(animal_id);
            if (animal == null)
                throw new AnimalNotFoundException();

            if (animal.Status == EnumAnimalStatus.Adopted)
                throw new AnimalAlreadyAdoptedException(animal.Id, animal.Name);

            var user = _userRepo.GetUserById(adopter_id);
            if (user == null)
                throw new AdopterNotFoundException();

            var adoption = new Adoption
            {
                AnimalId = animal.Id,
                Animal = animal,
                UserId = user.UserId,
                User = user,
                CreatedBy = user.UserName
            };
            animal.Status = EnumAnimalStatus.Adopted;
            animal.Adoption = adoption;

            _adoptionRepo.AddAdoption(adoption);
        }

        public void DeleteAdoption(int adoptionId)
        {
            var adoption = _adoptionRepo.GetById(adoptionId);
            if (adoption == null)
                throw new InvalidAdoptionRequestException("Adoption not found.");

            var animal = adoption.Animal;
            if (animal != null)
            {
                animal.Status = EnumAnimalStatus.Available;
                animal.Adoption = null;
            }

            _adoptionRepo.RemoveAdoption(adoptionId);
        }

        public void UpdateAdoption(int adoptionId, UpdateAdoptionDto dto)
        {
            var adoption = _adoptionRepo.GetById(adoptionId);
            if (adoption == null)
                throw new InvalidAdoptionRequestException("Adoption not found.");

            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.UserId.HasValue)
            {
                var user = _userRepo.GetUserById(dto.UserId.Value);
                if (user == null)
                    throw new AdopterNotFoundException();

                adoption.User = user;
                adoption.UserId = user.UserId;
            }

            if (dto.AnimalId.HasValue)
            {
                var newAnimal = _animalRepo.FindById(dto.AnimalId.Value);
                if (newAnimal == null)
                    throw new AnimalNotFoundException();

                if (newAnimal.Status == EnumAnimalStatus.Adopted)
                    throw new AnimalAlreadyAdoptedException(newAnimal.Id, newAnimal.Name);

                var oldAnimal = adoption.Animal;
                if (oldAnimal != null)
                {
                    oldAnimal.Status = EnumAnimalStatus.Available;
                    oldAnimal.Adoption = null;
                }

                newAnimal.Status = EnumAnimalStatus.Adopted;
                adoption.Animal = newAnimal;
                adoption.AnimalId = newAnimal.Id;
            }

            if (dto.AdoptedAt.HasValue)
                adoption.AdoptedAt = dto.AdoptedAt.Value;

            _adoptionRepo.UpdateAdoption(adoption);
        }
    }
}