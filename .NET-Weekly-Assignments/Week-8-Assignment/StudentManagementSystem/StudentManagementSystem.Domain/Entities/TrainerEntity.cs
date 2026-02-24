using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Domain.Entities
{
    public class TrainerEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Expertise { get; set; }

        public ICollection<StudentEntity> Students { get; set; } = new List<StudentEntity>();
        public ICollection<StudyMaterialEntity> StudyMaterials { get; set; }

    }
}
