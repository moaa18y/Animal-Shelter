using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Dto.AdoptionDtos
{
    public class AdoptionRequestDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int AnimalId { get; set; }

        [EmailAddress]
        public string AdopterUserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string AdopterEmail { get; set; } = string.Empty;

        public DateTime? AdoptedAt { get; set; }
    }
}