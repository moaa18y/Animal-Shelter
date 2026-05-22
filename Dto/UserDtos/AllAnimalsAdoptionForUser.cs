using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Dto.UserDtos
{
    public class AllAnimalsAdoptionForUser
    {
        public int id { get; set; }
        public string name { get; set; }

        public int age { get; set; }

        public List<AllVaccinesForEachAnimalAdoptByUser> Vaccines { get; set; }
    }
}
