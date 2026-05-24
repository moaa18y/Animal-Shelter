using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Dto
{
    public class UpdateVaccineDto
    {
        public string VaccineName { get; set; }
        public string VaccineDescription { get; set; }

        public int AnimalId { get; set; }
    }
}
