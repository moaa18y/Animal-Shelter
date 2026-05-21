using Animal_Shelter_V2.GlobalFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Animal_Shelter_V2.src.Models
{
    internal class Role : BaseEntity
    {
        
        [Key]
       public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = EnumRole.User.ToString(); //Default role is set to "User"

        
         public ICollection<User> Users { get; set; }
    }
}
