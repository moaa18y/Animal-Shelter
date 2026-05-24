
using Animal_Shelter_V2.src.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.DbForMigration;
using Microsoft.EntityFrameworkCore;
using Animal_Shelter_V2.src.Models;
using Animal_Shelter_V2.src.Models.implementation;
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

        public int Count => _dbContext.Animals.Count();

        public void Add(Animal animal)
        {
            if (animal == null) throw new ArgumentNullException(nameof(animal));
            if (_dbContext.Animals.Any(a => a.Id == animal.Id))
                throw new InvalidOperationException($"An animal with ID {animal.Id} already exists.");

            _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();
        }

        public bool Remove(int id)
        {
            var animal = _dbContext.Animals.Find(id);
            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();
            return true;
        }

        public Animal FindById(int id)
        {
            return _dbContext.Animals
                .Include(a => a.Vaccines)
                .Include(a => a.Adoption)
                .FirstOrDefault(a => a.Id == id);
        }

        public List<Animal> FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Cannot be empty.", nameof(name));

            return _dbContext.Animals
                .Include(a => a.Vaccines)
                .Where(a => EF.Functions.Like(a.Name, $"%{name}%"))
                .ToList();
        }

        public List<Animal> FindByStatus(AnimalStatus status)
        {
            return _dbContext.Animals
                .Include(a => a.Vaccines)
                .Where(a => a.Status == status)
                .ToList();
        }

        public void UpdateStatus(int id, AnimalStatus newStatus)
        {
            var animal = _dbContext.Animals.Find(id);
            if (animal == null) throw new AnimalNotFoundException(id);
            animal.Status = newStatus;
            _dbContext.SaveChanges();
        }

        public void AddAdoption(Adoption adoption)
        {
            if (adoption == null)
                throw new ArgumentNullException(nameof(adoption));

            _dbContext.Adoptions.Add(adoption);

            var animal = adoption.Animal;
            if (animal == null)
                animal = _dbContext.Animals.Find(adoption.AnimalId);

            if (animal != null)
            {
                animal.Status = AnimalStatus.Adopted;
                animal.Adoption = adoption;
            }

            _dbContext.SaveChanges();
        }

        public void AddCareNote(int id, string note)
        {
            var animal = _dbContext.Animals.Include(a => a.Vaccines).FirstOrDefault(a => a.Id == id);

            var careRecord = new Vaccine
            {
                VaccineName = "CareNote",
                VaccineDescription = note,
                VaccineDate = DateTime.Now
            };

            animal.Vaccines ??= new List<Vaccine>();
            animal.Vaccines.Add(careRecord);
            _dbContext.SaveChanges();
        }

        public IReadOnlyList<Animal> GetAll()
        {
            return _dbContext.Animals
                .Include(a => a.Vaccines)
                .Include(a => a.Adoption)
                .OrderBy(a => a.Id)
                .ToList()
                .AsReadOnly();
        }
    }
}
