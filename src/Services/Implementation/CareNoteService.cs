using Animal_Shelter_V2.src.Models;
using Animal_Shelter_V2.src.Repositories.Interfaces;
using AnimalShelter.CustomException;
using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.src.Services.Interfaces;
using System;

namespace Animal_Shelter.src.Services.Implementation
{
    public class CareNoteService : ICareNoteService
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly ICareNoteRepo _careNoteRepo;

        public CareNoteService(IAnimalRepository animalRepo, ICareNoteRepo careNoteRepo)
        {
            _animalRepo = animalRepo ?? throw new RepoNotFoundException(nameof(animalRepo));
            _careNoteRepo = careNoteRepo ?? throw new RepoNotFoundException(nameof(careNoteRepo));
        }

        public void AddCareNote(int animalId, string note)
        {
            if (string.IsNullOrWhiteSpace(note))
                throw new InvalidCareNoteException("Note cannot be empty.");

            var animal = _animalRepo.FindById(animalId);
            if (animal == null)
                throw new AnimalNotFoundException();

            var careNote = new CareNote
            {
                AnimalId = animal.Id,
                Animal = animal,
                Note = note
            };

            _careNoteRepo.AddCareNote(careNote);
        }

        public void DeleteCareNote(int careNoteId)
        {
            var careNote = _careNoteRepo.GetById(careNoteId);
            if (careNote == null)
                throw new InvalidCareNoteException("Care note not found.");

            _careNoteRepo.RemoveCareNote(careNoteId);
        }
    }
}