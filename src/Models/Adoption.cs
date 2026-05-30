
using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.src.Models
{
    public class Adoption: BaseEntity
    {
        [Key]
        public int AdoptionId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public Animal? Animal { get; set; }


        public DateTime AdoptedAt { get; set; }= DateTime.Now; 
    }
}
