using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Dto.UserDtos
{
    public class AnimalDto
    {
        public int id { get; set; }
        public string name { get; set; }

        public int age { get; set; }

        public List<GetVaccineDto> Vaccines { get; set; }
    }
}
