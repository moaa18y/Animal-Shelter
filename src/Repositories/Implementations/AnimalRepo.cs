using AnimalShelter.src.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.src.Shared.DbLayer;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.src.Models;
using AnimalShelter.src.Shared.Enums;

using AnimalShelter.src.Shared.CustomException;

namespace AnimalShelter.src.Repositories.Implementations
{
    public class AnimalManager : IAnimalRepository
    {
        private readonly AppDBContext _dbContext;

        public AnimalManager(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new DbContextNotFoundException(nameof(dbContext));
        }


        public void Add(Animal animal)
        {
            
            _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();
        }

        public bool Remove(int id)
        {
            var animal = _dbContext.Animals.Find(id);
            if (animal == null)
                return false;

            
            animal.IsDeleted = true;
            animal.DeletedAt = DateTime.Now;
            _dbContext.SaveChanges();
            return true;
        }

        public Animal FindById(int id)
        {
            return _dbContext.Animals
                .Include(a => a.Vaccines)
                .Include(a=>a.CareNotes)
                .FirstOrDefault(a => a.Id == id);
        }
        public Animal FindByIdReadOnly(int id)
        {
            return _dbContext.Animals
                .Include(a => a.Vaccines)
                .Include(a=>a.CareNotes)
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);
        }
        public void UpdateStatus(int id, EnumAnimalStatus newStatus)
        {
            var animal = _dbContext.Animals.Find(id);
            animal.Status = newStatus;
            _dbContext.SaveChanges();
        }

        

       

        public IReadOnlyList<Animal> GetAll()
        {
            return _dbContext.Animals
                .Include(a => a.Vaccines)
                .Include(a=>a.CareNotes)
                .OrderBy(a => a.Id).AsNoTracking()
                .ToList();
        }
    }
}
