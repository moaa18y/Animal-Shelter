using AnimalShelter.src.Models;
using AnimalShelter.src.Models;
using AnimalShelter.src.Shared.GlobalFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



public  class Animal :BaseEntity     
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 30, ErrorMessage = "Age must be between 0 and 30.")]
        public int Age { get; set; }

        public EnumAnimalSpecies Species { get; set; }
        
        public EnumAnimalStatus Status { get; set; }=EnumAnimalStatus.Available;// Default status is set to "Available"

        public Adoption? Adoption { get; set; }

        public List<Vaccine>? Vaccines { get; set; }
        public List<CareNote>? CareNotes { get; set; }


        // dog
        public string? Breed { get; set; } 
        public EnumAnimalSize? Size { get; set; }

        // cat
        public string? Color { get; set; }       
        public bool? IsIndoor { get; set; }
        
        // bird
             
        public bool? CanFly { get; set; }

        //small animal
        public string? AnimalType { get; set; }
        public bool? IsNocturnal { get; set; }

}
