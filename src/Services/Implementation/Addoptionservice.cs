
using Animal_Shelter.CustomException;
using Animal_Shelter.src.Repositories.Implementations;
using Animal_Shelter_V2.src.Models;
using Animal_Shelter_V2.src.Repositories.Implementations;
using Animal_Shelter_V2.src.Repositories.Interfaces;

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
        private readonly AdoptionRepo _adoptionRepo;
        private readonly IUserRepo _userRepo;
        public Addoptionservice(IAnimalRepository animalRepo, AdoptionRepo adoptionRepo, IUserRepo userRepo)
        {
            _animalRepo = animalRepo ?? throw new RepoNotFoundException(nameof(animalRepo));
            _adoptionRepo = adoptionRepo ?? throw new RepoNotFoundException(nameof(adoptionRepo));
            _userRepo = userRepo ?? throw new RepoNotFoundException(nameof(userRepo));
        }
        public void AdoptAnimal(int animal_id, string adopter_id)
        {

            var animal = _animalRepo.FindById(animal_id);
            if (animal == null)
                throw new AnimalNotFoundException();

            if (animal.Status == EnumAnimalStatus.Adopted)
                throw new AnimalAlreadyAdoptedException(animal.Id, animal.Name);

           // var user = _userRepo.GetUserById(adopter_id);
            //if (user == null)
            //    throw new AdopterNotFoundException();

            //var adoption = new Adoption
            //{
            //    AnimalId = animal.Id,
            //    Animal = animal,
            //    UserId = user.UserId,
            //    User = user,            
            //    CreatedBy = user.UserName
            //};
            //animal.Status = EnumAnimalStatus.Adopted;
            //animal.Adoption = adoption;

            //_repo.AddAdoption(adoption);
        }
    }
}