using AnimalShelter.src.Shared.Dto.AnimalDtos;
using System.Collections.Generic;



public interface IAnimalService
    {
        void AddAnimal(AddAnimalDto animalDto);
        bool RemoveAnimal(int id);

        GetAnimalDto GetAnimal(int id);
        List<GetAnimalDto> GetAllAnimals();
        
       

        // Needed for non-adoption status changes routed through the service layer
        void UpdateStatus(int id, EnumAnimalStatus newStatus);
    }

