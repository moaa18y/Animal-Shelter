using AnimalShelter.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_Shelter.Services
{
    public interface IAnimalService
    {
        void AddAnimal(int type);
        bool RemoveAnimal(int id);

        Animal GetAnimal(int id);
        List<Animal> GetAllAnimals();

        List<Animal> SearchByName(string name);
        List<Animal> GetByStatus(AnimalStatus status);

        void AdoptAnimal(int id, string adopterName);
        void AddCareNote(int id, string note);
    }
}
