using AnimalShelter.src.Shared.Dto.AnimalDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.Dto.Adoption
{
    public class AdoptionsDto
    {
        public int id {  get; set; }

        public DateTime AdoptedAt { get; set; }

        public GetAnimalDto Animal { get; set; }
    }
}
