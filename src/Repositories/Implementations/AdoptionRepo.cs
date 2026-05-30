using AnimalShelter.src.Models;
using AnimalShelter.CustomException;
using AnimalShelter.DbForMigration;
using AnimalShelter.src.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.src.Repositories.Implementations
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

        public List<Adoption> GetAllAdoptions()
        {
            return _dbContext.Adoptions.ToList();
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