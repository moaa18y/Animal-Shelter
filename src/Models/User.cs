using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Animal_Shelter_V2.src.Models
{
    internal class User :BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }

        public int RoleId { get; set; }
        
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        
    }
}
