using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
