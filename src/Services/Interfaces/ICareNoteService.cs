using AnimalShelter.Dto;
using AnimalShelter.src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Services.Interfaces
{
    public interface ICareNoteService
    {
        void AddNote(AddCareNoteDto note, String CurrentUser);

        void DeleteNote(int id);

        void UpdateNote(int id, UpdateCareNoteDto NoteDto, String CurrentUser);
    }
}
