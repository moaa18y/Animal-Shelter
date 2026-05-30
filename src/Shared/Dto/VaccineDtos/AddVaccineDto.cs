using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.Dto.Vaccine
{
    public class AddVaccineDto
    {
        public string VaccineName { get; set; }
        public string VaccineDescription { get; set; }

        public int AnimalId { get; set; }
    }
}
