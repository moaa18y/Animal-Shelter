
using Animal_Shelter_V2.src.Models;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Shelter_V2.src.Repositories.Interfaces
{
    public interface IAnimalRepository
    {

        void Add(Animal animal);
        bool Remove(int id);

        Animal FindById(int id);

        public Animal FindByIdReadOnly(int id);
       
        void UpdateStatus(int id, EnumAnimalStatus newStatus);

        IReadOnlyList<Animal> GetAll();
    }
}
