
using System.ComponentModel.DataAnnotations;


namespace Animal_Shelter_V2.src.Models.implementation
{
    public  class Dog : Animal
    {
        [Required]
        public string Breed { get; set; } = string.Empty;

        [Required]
        public string Size { get; set; } = string.Empty;
        
        
        
        //public Dog(int id, string name, int age,string breed,bool isVaccinated,string size, AnimalStatus status = AnimalStatus.Available)
        //    : base(id, name, age, status)
        //{
        //    Breed = breed;
        //    Size = size;
        //    IsVaccinated = isVaccinated;
        //}

        //public override string GetSpeciesInfo()
        //    => $"Dog | Breed: {Breed} | Size: {Size} | Vaccinated: {(IsVaccinated?"Yes":"No")}";
    }
}
