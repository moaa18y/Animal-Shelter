

using System.Collections.Generic;



public interface IAnimalService
    {
        void AddAnimal(Animal animal);
        bool RemoveAnimal(int id);

        Animal GetAnimal(int id);
        List<Animal> GetAllAnimals();
        
        void AddCareNote(int id, string note);

        // Needed for non-adoption status changes routed through the service layer
        void UpdateStatus(int id, EnumAnimalStatus newStatus);
    }

