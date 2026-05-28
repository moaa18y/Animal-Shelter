using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Vaccine : BaseEntity
   {
        [Key]
        public int VaccineId { get; set; }

        [Required]
        public string VaccineName { get; set; }

        [Required]
        public string VaccineDescription { get; set; }

        
        public DateTime VaccineDate { get; set; }= DateTime.Now;

       
        
        public int AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public Animal? Animal { get; set; }
       
   }

