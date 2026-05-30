using AnimalShelter.CustomException;
using AnimalShelter.DbForMigration;
using AnimalShelter.src.Models;
using AnimalShelter.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.src.Repositories.Implementations
{
    public class CareNoteRepo : ICareNoteRepo
    {
        private readonly AppDBContext _appDbContext;

        public CareNoteRepo(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;
        }
        public void AddNote(CareNote note, String CurrentUser)
        {
            note.CreatedBy = CurrentUser;
            _appDbContext.Add(note);
            _appDbContext.SaveChanges();

        }

        public void DeleteNote(CareNote note)
        {
            
            note.IsDeleted = true;
             _appDbContext.SaveChanges();
        }

        public CareNote GetNote(int id)
        {
            return _appDbContext.CareNotes
                .FirstOrDefault(x => x.Id == id);
        }
        

       public void UpdateNote(CareNote Newnote, CareNote note, String CurrentUser)
        {

            note.Title = Newnote.Title;
            note.Description = Newnote.Description;
            note.AnimalId = Newnote.AnimalId;
            note.UpdatedAt=DateTime.Now;
            note.UpdatedBy = CurrentUser;
            _appDbContext.SaveChanges();
        }
    }
}
