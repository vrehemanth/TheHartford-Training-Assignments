using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFSeedingDemo.Models
{
    [Table("States")]
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string StateName { get; set; }
        public int CountryId { get; set; } // Foreign Key

        // Navigation Properties
        public Country? Country { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
