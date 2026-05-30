using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalShelter.src.Shared.Dto.CareNoteDtos
{
    public class AddCareNoteDto
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int AnimalId { get; set; }
    }
}
