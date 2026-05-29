
using Animal_Shelter.CustomException;
using Animal_Shelter.src.Repositories.Implementations;
using Animal_Shelter_V2.src.Models;
using Animal_Shelter_V2.src.Repositories.Implementations;
using Animal_Shelter_V2.src.Repositories.Interfaces;

using AnimalShelter.CustomException;

using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Animal_Shelter.src.Services.Implementation
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
                CreatedBy = user.UserName
            };
            animal.Status = EnumAnimalStatus.Adopted;
            animal.Adoption = adoption;
            if (user.Adoptions == null)
                user.Adoptions = new List<Adoption>();
            user.Adoptions.Add(adoption);
            _adoptionRepo.AddAdoption(adoption);
            _animalRepo.UpdateStatus(animalId, EnumAnimalStatus.Adopted);
        }
    }
}