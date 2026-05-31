using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.src.Shared.CustomException;
using AnimalShelter.src.Models;
using AnimalShelter.src.Repositories.Implementations;
using AnimalShelter.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AnimalShelter.src.Shared.Dto.CareNoteDtos;

namespace AnimalShelter.src.Services.Implementation
{
    public class CareNoteService : ICareNoteService
    {
        private readonly ICareNoteRepo _repo;
        private readonly IAnimalService _animalService;

        public CareNoteService(ICareNoteRepo careNoteService, IAnimalService animalService)
        {
            _repo = careNoteService;
            _animalService = animalService;
        }
        public void AddNote(AddCareNoteDto note, string CurrentUser)
        {
            var animal = _animalService.GetAnimal(note.AnimalId);
            var noteM = new CareNote
            { 
                AnimalId = note.AnimalId,
                Title = note.Title,
                Description = note.Description,
                           
            };

            _repo.AddNote(noteM, CurrentUser); 
        }

        public void DeleteNote(int id)
        {
            var note=_repo.GetNote(id);
            if (note is null)
            {
                throw new NoteNotFoundException();
            }
            _repo.DeleteNote(note);

        }

       

        public void UpdateNote(int id, UpdateCareNoteDto NoteDto, string CurrentUser)
        {
             var note = _repo.GetNote(id);

            var NewNote = new CareNote
            {
                AnimalId = NoteDto.AnimalId,
                Title = NoteDto.Title,
                Description = NoteDto.Description,
            };
            _repo.UpdateNote(NewNote, note, CurrentUser);

        }
    }
}
