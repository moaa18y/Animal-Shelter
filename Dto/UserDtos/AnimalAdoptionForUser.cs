using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Dto.UserDtos
{
    public class AnimalAdoptionForUser
    {
        public int id { get; set; }
        public string name { get; set; }

        public int age { get; set; }

        public List<VaccineForEachAnimalAdoptByUser> Vaccines { get; set; }
    }
}
