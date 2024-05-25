using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public int ChapterId { get; set; }
        public virtual ChapterStudy? Chapter { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string LinkVideo { get; set; }
        public int VideoDuration { get; set; }
        public int LessonStatusId { get; set; }
        public virtual LessonStatus? LessonStatus { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }
        public virtual ICollection<CommentLesson>? CommentLessons { get; set; }
        public virtual ICollection<UserLessonCheckpoint>? UserLessonCheckpoints { get; set; }
    }
}
