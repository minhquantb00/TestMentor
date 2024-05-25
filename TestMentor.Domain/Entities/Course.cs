using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int TotalDuration { get; set; }
        public int NumberOfSubcribers { get; set; }
        public int NumberOfCompleted { get; set; }
        public int CourseTypeId { get; set; }
        public virtual CourseType? CourseType { get; set; }
        public int TotalLesson { get; set; }
        public virtual ICollection<ChapterStudy>? ChapterStudies { get; set; }
        public virtual ICollection<AssigningTeachingAssistants>? AssigningTeachingAssistants { get; set; }
        public virtual ICollection<RegisterCourse>? RegisterCourse { get; set; }
    }
}
