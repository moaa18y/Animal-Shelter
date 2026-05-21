using Animal_Shelter_V2.src.Models.implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal_Shelter_V2.src.Models
{
    internal class Adoption: BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; }

        public DateTime AdoptedAt { get; set; }= DateTime.Now; //Default value set to current date and time
    }
}
