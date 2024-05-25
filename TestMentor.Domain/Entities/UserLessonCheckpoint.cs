using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class UserLessonCheckpoint : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson? Lesson { get; set; }
        public DateTime OpenTime { get; set; }
        public bool? IsDone { get; set; }
    }
}
