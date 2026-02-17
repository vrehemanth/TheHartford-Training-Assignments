using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFSeedingDemo.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CityName { get; set; }
        public int StateId { get; set; } // Foreign Key

        // Navigation Property
        public State? State { get; set; }
    }
}
