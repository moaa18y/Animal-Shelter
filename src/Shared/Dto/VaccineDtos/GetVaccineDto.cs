using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.Dto.Vaccine
{
    public class GetVaccineDto
    {
        public int Id { get; set; }

        public string VaccineName { get; set; } 

        public DateTime VaccineDate { get; set; }

    }
}
