using AnimalShelter.src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Repositories.Interfaces
{
    public interface ICareNoteRepo
    {
        void AddNote(CareNote note, String CurrentUser);

        CareNote GetNote(int id);

        void DeleteNote(CareNote note);

        void UpdateNote(CareNote Newnote,CareNote note, String CurrentUser);
    }
}
