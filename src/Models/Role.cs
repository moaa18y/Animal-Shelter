
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AnimalShelter.src.Shared.Enums;


namespace AnimalShelter.src.Models
{
    public class Role : BaseEntity
    {
        
        [Key]
       public int RoleId { get; set; }

        [Required]
        public EnumRole RoleName { get; set; } = EnumRole.User; //Default role is set to "User"

        
         public ICollection<User> Users { get; set; }
    }
}
