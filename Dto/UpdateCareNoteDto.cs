using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalShelter.Dto
{
    public class UpdateCareNoteDto
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public int AnimalId { get; set; }
    }
}
