using Animal_Shelter_V2.src.Factory.Implementations;
using Animal_Shelter_V2.src.Repositories.Implementations;
using Animal_Shelter_V2.src.Models.implementation;
using Animal_Shelter_V2.src.Repositories.Interfaces;
using AnimalShelter.Dto.AdoptionDtos;
using AnimalShelter.CustomException;
using Animal_Shelter_V2.src.Validators;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Animal_Shelter_V2.src.Services.Implementation
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repo;
        private readonly IUserRepo _userRepo;

        public AnimalService(IAnimalRepository repo, IUserRepo userRepo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        public void AddAnimal(int type)
        {
            throw new NotSupportedException("Animal creation should use a DTO-based EF flow. The old factory-based console input flow is retired.");
        }

        public bool RemoveAnimal(int id)
        {
            var animal = _repo.FindById(id);

            if (animal == null)
                throw new AnimalNotFoundException(id);

            return _repo.Remove(id);
        }

        public Animal GetAnimal(int id)
        {
            var animal = _repo.FindById(id);
            if (animal == null)
                throw new AnimalNotFoundException(id);
            return animal;
        }

        public List<Animal> GetAllAnimals()
        {
            return _repo.GetAll().ToList();
        }

        public List<Animal> SearchByName(string name)
        {
            return _repo.FindByName(name);
        }

        public List<Animal> GetByStatus(AnimalStatus status)
        {
            return _repo.FindByStatus(status);
        }

        public void AdoptAnimal(int id, string adopterName)
        {
            DtoValidator.Validate(new AdoptionRequestDto
            {
                AnimalId = id,
                AdopterEmail = adopterName
            });

            var animal = _repo.FindById(id);
            if (animal == null)
                throw new AnimalNotFoundException(id);

            if (animal.Status == AnimalStatus.Adopted)
                throw new AnimalAlreadyAdoptedException(animal.Id, animal.Name);

            var user = _userRepo.FindByEmail(adopterName);
            if (user == null)
                throw new AdopterNotFoundException(string.Empty, adopterName);

            var adoption = new Adoption
            {
                AnimalId = animal.Id,
                Animal = animal,
                UserId = user.UserId,
                User = user,            
                CreatedBy = user.UserName
            };

            _repo.AddAdoption(adoption);
        }

        public void AddCareNote(int id, string note)
        {
            if (string.IsNullOrWhiteSpace(note))
                throw new InvalidCareNoteException("Note cannot be empty.");

            var animal = _repo.FindById(id);
            if (animal == null)
                throw new AnimalNotFoundException(id);

            _repo.AddCareNote(id, note);
        }

        public void UpdateStatus(int id, AnimalStatus newStatus)
        {
            var animal = _repo.FindById(id);
            if (animal == null)
                throw new AnimalNotFoundException(id);

            _repo.UpdateStatus(id, newStatus);
        }
    }
}
