using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnimalShelter.src.Models
{
    public class CareNote :BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int AnimalId { get; set; }
        [ForeignKey(nameof(AnimalId))]
        public Animal Animal { get; set; }
    }
}
