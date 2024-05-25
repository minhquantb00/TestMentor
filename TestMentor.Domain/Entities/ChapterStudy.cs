using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class ChapterStudy : BaseEntity
    {
        public string Name { get; set; }
        public int TotalDuration { get; set; }
        public int TotalLesson { get; set; }
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public virtual ICollection<Lesson>? Lessons { get; set; }
    }
}
