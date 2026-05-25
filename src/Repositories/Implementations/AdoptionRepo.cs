using Animal_Shelter_V2.src.Models;
using AnimalShelter.DbForMigration;
using AnimalShelter.src.Repositories.Interfaces;
using System;

namespace Animal_Shelter.src.Repositories.Implementations
{
    public class AdoptionRepo : IAdoptionRepo
    {
        private readonly AppDBContext _dbContext;
        public AdoptionRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new RepoNotFoundException(nameof(dbContext));
            
        }
        public void AddAdoption(Adoption adoption)
        {    
            _dbContext.Adoptions.Add(adoption);
            _dbContext.SaveChanges();
        }
        public Adoption GetById(int id)
        {
            return _dbContext.Adoptions.Find(id);
        }

        public void RemoveAdoption(int id)
        {
            var adoption = _dbContext.Adoptions.Find(id);
            if (adoption == null) return;
            adoption.IsDeleted = true;
            adoption.DeletedAt = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public void UpdateAdoption(Adoption adoption)
        {
            _dbContext.Adoptions.Update(adoption);
            _dbContext.SaveChanges();
        }
    }
}