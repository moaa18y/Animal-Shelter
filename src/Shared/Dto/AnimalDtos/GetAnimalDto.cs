using AnimalShelter.src.Models;
using AnimalShelter.src.Shared.Dto.CareNoteDtos;
using AnimalShelter.src.Shared.Dto.Vaccine;
using AnimalShelter.src.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.Dto.AnimalDtos
{
    public class GetAnimalDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public EnumAnimalSpecies Species { get; set; }

        public EnumAnimalStatus Status { get; set; }

        public List<GetVaccineDto>? Vaccines { get; set; }
        public List<GetCareNoteDto>? careNotes { get; set; }

        // Dog
        public string? Breed { get; set; }

        public EnumAnimalSize? Size { get; set; }

        // Cat
        public string? Color { get; set; }

        public bool? IsIndoor { get; set; }

        // Bird
        public bool? CanFly { get; set; }

        // Small Animal
        public string? AnimalType { get; set; }

        public bool? IsNocturnal { get; set; }
    }
}
