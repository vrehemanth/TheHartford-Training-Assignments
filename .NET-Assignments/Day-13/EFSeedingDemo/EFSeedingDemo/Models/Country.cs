using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFSeedingDemo.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CountryName { get; set; }
        [Required]
        [MaxLength(10)]
        public required string CountryCode { get; set; }
        // Navigation Property
        public ICollection<State>? States { get; set; }
    }
}
