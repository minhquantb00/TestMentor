using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class RegisterCourse : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }
        public DateTime RegisterTime { get; set; }
        public int CurrentLessonId { get; set; }
        public virtual Lesson? CurrentLesson { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
