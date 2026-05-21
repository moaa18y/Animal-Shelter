
using System.ComponentModel.DataAnnotations;


namespace Animal_Shelter_V2.src.Models.implementation
{
    public  class Bird : Animal
    {
        [Required]
        public string Species {  get; set; }

        [Required]
        public string WingSpan { get; set; }

        [Required]
        public bool CanFly { get; set; }


        //public Bird(int id, string name, int age,string species,bool canFly,string wingspan, AnimalStatus status = AnimalStatus.Available) 
        //    : base(id, name, age, status)
        //{
        //    Species = species;
        //    CanFly = canFly;
        //    WingSpan = wingspan;
        //}

        //public override string GetSpeciesInfo()
        //    => $"Bird | Species: {Species} | Can Fly: {(CanFly ? "Yes" : "No")} | Wingspan: {WingSpan}";
    }
}
