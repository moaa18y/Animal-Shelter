using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Animal_Shelter_V2.src.Models
{
    internal class Vaccine : BaseEntity
    {
        [Key]
        public int VaccineId { get; set; }

        [Required]
        public string VaccineName { get; set; }

        [Required]
        public string VaccineDescription { get; set; }

        [Required]
        public DateTime VaccineDate { get; set; }= DateTime.Now;
       
    }
}
