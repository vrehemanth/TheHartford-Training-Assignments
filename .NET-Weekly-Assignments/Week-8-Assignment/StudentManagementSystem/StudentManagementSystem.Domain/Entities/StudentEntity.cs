using StudentManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Domain.Entities
{
    public class StudentEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; } = string.Empty;
        public UserEntity User { get; set; }

        public string Course { get; set; }
        public string EnrollmentNumber { get; set; }

        public Guid? TrainerId { get; set; }
        public TrainerEntity? Trainer { get; set; }

        public ICollection<FeedbackEntity> Feedbacks { get; set; }
        public int Progress { get; set; }
        public ICollection<StudentNoteEntity> Notes { get; set; }
    }
}
