using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal_Shelter_V2.src.Models
{
    public class CareNote : BaseEntity
    {
        [Key]
        public int CareNoteId { get; set; }

        [Required]
        public string Note { get; set; }

        public int AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public Animal Animal { get; set; }
    }
}