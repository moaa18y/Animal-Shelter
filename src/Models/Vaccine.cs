using System;

using System.ComponentModel.DataAnnotations;


   public class Vaccine : BaseEntity
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

