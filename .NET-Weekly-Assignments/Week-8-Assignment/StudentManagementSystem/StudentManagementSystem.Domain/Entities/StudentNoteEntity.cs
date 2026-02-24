using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Domain.Entities
{
    public class StudentNoteEntity
    {
        public int Id { get; set; }

        public string Note { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        // FK → Student
        public Guid StudentId { get; set; }
        public StudentEntity Student { get; set; }
    }
}
