using AnimalShelter.Dto.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Dto
{
    public class AdoptionsDto
    {
        public int id {  get; set; }

        public DateTime AdoptedAt { get; set; }

        public AnimalDto Animal { get; set; }
    }
}
