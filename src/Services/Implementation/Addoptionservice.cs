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
namespace Animal_Shelter.src.Services.Implementation
{
    public class Addoptionservice
    {
        private readonly IAnimalRepository _repo;
        private readonly IUserRepo _userRepo;
        public AnimalService(IAnimalRepository repo, IUserRepo userRepo)
        {
            _repo = repo ?? throw new RepoNotFoundException();
            _userRepo = userRepo ?? throw new RepoNotFoundException();
        }
        public void AdoptAnimal(int animal_id, string adopter_id)
        {

            var animal = _repo.FindById(animal_id);
            if (animal == null)
                throw new AnimalNotFoundException(animal_id);

            if (animal.Status == AnimalStatus.Adopted)
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
            animal.Status = AnimalStatus.Adopted;
            animal.Adoption = adoption;

            _repo.AddAdoption(adoption);
        }
    }
}