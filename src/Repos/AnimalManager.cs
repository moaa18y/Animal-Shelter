using AnimalShelter.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_Shelter.Repos
{
    public class AnimalManager : IAnimalRepository
    {
        private readonly List<Animal> _animals = new();
        private int _nextId = 1;

        public int Count => _animals.Count;

        public int NextId() => _nextId++;

        public void Add(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));

            _animals.Add(animal);
        }

        public bool Remove(int id)
        {
            var animal = FindById(id);
            if (animal == null) return false;

            _animals.Remove(animal);
            return true;
        }

        public Animal FindById(int id)
            => _animals.FirstOrDefault(a => a.Id == id);

        public List<Animal> FindByName(string name)
            => _animals
                .Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

        public List<Animal> FindByStatus(AnimalStatus status)
            => _animals.Where(a => a.Status == status).ToList();

        public void UpdateStatus(int id, AnimalStatus newStatus)
        {
            var animal = FindById(id);
            if (animal == null)
                throw new Exception("Animal not found");

            animal.Status = newStatus;
        }

        public IReadOnlyList<Animal> GetAll()
            => _animals.AsReadOnly();
    }
}
