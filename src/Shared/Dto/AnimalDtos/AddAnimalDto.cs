using AnimalShelter.src.Shared.GlobalFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalShelter.src.Shared.Dto.AnimalDtos
{
    public class AddAnimalDto
    {
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 30)]
        public int Age { get; set; }

        [Required]
        public EnumAnimalSpecies Species { get; set; }

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

