using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.DTOS
{
    public class AssignTrainerDto
    {
        public Guid TrainerId { get; set; }
        public Guid StudentId { get; set; }
    }
}
