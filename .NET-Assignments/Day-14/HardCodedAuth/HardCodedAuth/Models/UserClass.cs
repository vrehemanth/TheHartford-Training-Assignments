using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace AAApi.Models
{
    public class UserClass
    {
        [Key]
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime LastModifiedTime { get; set; } = DateTime.UtcNow;
    }
}
