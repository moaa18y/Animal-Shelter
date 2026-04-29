using AnimalShelter.src.Models;


namespace animal_Shelter.Repos
{
    public class AnimalManager : IAnimalRepository
    {
        private readonly List<Animal> _animals;
        private int _nextId;

        public AnimalManager()
        {
            _animals = new List<Animal>();
            _nextId = 1;
        }

        //IAnimalRepository implementation
        public int Count => _animals.Count;

        public int NextId() => _nextId++;

        public void Add(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));
            if (_animals.Any(a => a.Id == animal.Id))
                throw new InvalidOperationException(
                    $"An animal with ID {animal.Id} already exists.");
            _animals.Add(animal);
        }

        public bool Remove(int id)
        {
            var animal = FindById(id);
            if (animal == null) 
                return false;
            _animals.Remove(animal);
            return true;
        }

        public Animal FindById(int id)
            => _animals.FirstOrDefault(a => a.Id == id);

        public List<Animal> FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Cannot be empty.", nameof(name));
            return _animals
                .Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
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
            => _animals.OrderBy(a => a.Id).ToList().AsReadOnly();
    }
}
