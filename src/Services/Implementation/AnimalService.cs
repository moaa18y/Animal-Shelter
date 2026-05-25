
using System;
using System.Collections.Generic;
using System.Linq;
using Animal_Shelter_V2.src.Repositories.Interfaces;
using AnimalShelter.Dto.UserDtos;
using AnimalShelter.CustomException;
using AnimalShelter.src.Repositories.Interfaces;

namespace Animal_Shelter_V2.src.Services.Implementation
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repo;
        private readonly ICareNoteService _careNoteService;
        private readonly IUserRepo _userRepo;

        public AnimalService(IAnimalRepository repo, IUserRepo userRepo, ICareNoteService careNoteService)
        {
            _repo = repo ?? throw new RepoNotFoundException(nameof(repo));
            _careNoteService = careNoteService ?? throw new RepoNotFoundException(nameof(careNoteService));
            _userRepo = userRepo ?? throw new RepoNotFoundException(nameof(userRepo));
        }

        public void AddAnimal(AnimalDto animalDto)
        {
            if (animalDto == null)
                throw new ArgumentNullException(nameof(animalDto));

            var animal = new Animal
            {
                Name = animalDto.name ?? string.Empty,
                Age = animalDto.age,
                Vaccines = null
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

        public Animal GetAnimal(int id)
        {
            var animal = _repo.FindById(id);
            if (animal == null)
                throw new AnimalNotFoundException();
            return animal;
        }

        public List<Animal> GetAllAnimals()
        {
            return _repo.GetAll().ToList();
        }

        public void AddCareNote(int id, string note)
        {
            if (string.IsNullOrWhiteSpace(note))
                throw new InvalidCareNoteException("Note cannot be empty.");

            var animal = _repo.FindById(id);
            if (animal == null)
                throw new AnimalNotFoundException();

            _careNoteService.AddCareNote(id, note);
        }

        public void DeleteCareNote(int id)
        {
            _careNoteService.DeleteCareNote(id);
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
