using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Dto
{
    public class AllVaccinesForEachAnimalAdoptByUser
    {
        public int Id { get; set; }

        public string VaccineName { get; set; } 

        public DateTime VaccineDate { get; set; }

    }
}
