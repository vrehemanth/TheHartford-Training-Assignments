using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.DTOS
{
    public class CreateFeedbackDto
    {
        public Guid MaterialId { get; set; }   
        public string Comments { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
