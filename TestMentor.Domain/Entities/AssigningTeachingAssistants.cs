using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class AssigningTeachingAssistants : BaseEntity
    {
        public int StudentId { get; set; }
        public int MentorId { get; set; }
        public virtual User? Mentor { get; set; }
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
