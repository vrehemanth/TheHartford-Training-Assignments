using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Domain.Entities
{
    public class FeedbackEntity
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public StudentEntity Student { get; set; } = null!;   // ✅ REQUIRED
        public Guid TrainerId { get; set; }

        public Guid? MaterialId { get; set; }
        public StudyMaterialEntity? Material { get; set; }

        public string Comments { get; set; } = string.Empty;
        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
