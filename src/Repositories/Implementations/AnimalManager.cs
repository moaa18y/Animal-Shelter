using Animal_Shelter_V2.src.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.DbForMigration;
using Microsoft.EntityFrameworkCore;
using Animal_Shelter_V2.src.Models;

using AnimalShelter.CustomException;

namespace Animal_Shelter_V2.src.Repositories.Implementations
{
    public class AnimalManager : IAnimalRepository
    {
        private readonly AppDBContext _dbContext;

        public AnimalManager(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public void Add(Animal animal)
        {
            if (_dbContext.Animals.Any(a => a.Id == animal.Id))
                throw new InvalidOperationException($"An animal with ID {animal.Id} already exists.");

            _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();
        }

        public bool Remove(int id)
        {
            var animal = _dbContext.Animals.Find(id);
            if (animal == null) return false;
            animal.IsDeleted = true;
            animal.DeletedAt = DateTime.Now;
            _dbContext.SaveChanges();
            return true;
        }

        public Animal FindById(int id)
        {
            return _dbContext.Animals
                .Include(a => a.Vaccines)
                .Include(a => a.CareNotes)
                .Include(a => a.Adoption)
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
                .Include(a => a.CareNotes)
                .Include(a => a.Adoption)
                .OrderBy(a => a.Id).AsNoTracking()
                .ToList();
        }
    }
}
