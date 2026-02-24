using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.DTOS
{
    public class FeedbackDto
    {
        public Guid StudentId { get; set; }
        public Guid TrainerId { get; set; }
        public Guid Id { get; set; }
        public string Comments { get; set; }
        public Guid? MaterialId { get; set; }
        public int? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
