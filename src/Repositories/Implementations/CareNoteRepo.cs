using Animal_Shelter_V2.src.Models;
using AnimalShelter.DbForMigration;
using AnimalShelter.src.Repositories.Interfaces;
using System;

namespace Animal_Shelter.src.Repositories.Implementations
{
    public class CareNoteRepo : ICareNoteRepo
    {
        private readonly AppDBContext _dbContext;

        public CareNoteRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddCareNote(CareNote careNote)
        {
            _dbContext.CareNotes.Add(careNote);
            _dbContext.SaveChanges();
        }

        public CareNote GetById(int id)
        {
            return _dbContext.CareNotes.Find(id);
        }

        public void RemoveCareNote(int id)
        {
            var careNote = _dbContext.CareNotes.Find(id);
            if (careNote == null) return;
            careNote.IsDeleted = true;
            careNote.DeletedAt = DateTime.Now;
            _dbContext.SaveChanges();
        }
    }
}