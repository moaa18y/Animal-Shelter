using Animal_Shelter_V2.GlobalFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Shelter_V2.src.Models
{
    public sealed class Cat : Animal
    {

        [Required]
        public string Color { get; set; } = string.Empty;

        [Required]
        public bool IsIndoor { get; set; }  
        

        //public Cat(int id, string name, int age,bool isIndoor,string color,bool isVaccinated, AnimalStatus status = AnimalStatus.Available) 
        //    : base(id, name, age, status)
        //{
        //    IsIndoor = isIndoor;
        //    Color = color;
        //    IsVaccinated = isVaccinated;
        //}

        //public override string GetSpeciesInfo()
        //      => $"Cat | Color: {Color} | {(IsIndoor ? "Indoor" : "Outdoor")} | Vaccinated: {(IsVaccinated ? "Yes" : "No")}";

    }
}
