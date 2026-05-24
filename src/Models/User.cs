
using Animal_Shelter_V2.src.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



[Index(nameof(UserEmail),IsUnique =true)]
    public class User :BaseEntity
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

        public int? RoleId { get; set; }
        
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

    public bool IsDeleted { get; set; } = false;

    public List<Adoption> Adoptions { get; set; }

        
    }

