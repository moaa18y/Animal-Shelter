
using System.ComponentModel.DataAnnotations;


namespace Animal_Shelter_V2.src.Models.implementation
{
    // Represents a small animal (rabbit, hamster, guinea pig, etc.)
    public  class SmallAnimal : Animal
    {

        [Required]
        public string AnimalType { get; set; } = string.Empty; // Type of small animal (e.g., "Rabbit", "Hamster", "Guinea Pig").

        // Habitat refers to the natural environment where the animal lives (e.g., "Desert", "Forest", "Sea", "Savannah").
        [Required]
        public string Habitat { get; set; } = string.Empty;

        //Nocturnal animals are active during the night and sleep during the day.
        [Required]
        public bool IsNocturnal { get; set; }

        //public SmallAnimal(int id, string name, int age, string animalType, string habitat, bool isNocturnal, AnimalStatus status = AnimalStatus.Available)
        //    : base(id, name, age, status)
        //{
        //    AnimalType = animalType;
        //    Habitat = habitat;
        //    IsNocturnal = isNocturnal;
        //}
        //public override string GetSpeciesInfo()
        //    => $"Small Animal | Type: {AnimalType} | Habitat: {Habitat} | Nocturnal: {(IsNocturnal ? "Yes" : "No")}";
    }
}
