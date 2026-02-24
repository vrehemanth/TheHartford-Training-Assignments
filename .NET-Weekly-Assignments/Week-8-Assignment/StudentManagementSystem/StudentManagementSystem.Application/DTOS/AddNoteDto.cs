using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.DTOS
{
    public class AddNoteDto
    {
        public Guid StudentId { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
