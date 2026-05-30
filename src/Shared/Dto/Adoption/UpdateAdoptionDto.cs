using System;

namespace AnimalShelter.src.Shared.Dto.Adoption
{
    public class UpdateAdoptionDto
    {
        public int? UserId { get; set; }
        public int? AnimalId { get; set; }
        public DateTime? AdoptedAt { get; set; }
    }
}
