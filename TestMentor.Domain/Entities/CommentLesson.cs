using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class CommentLesson : BaseEntity
    {
        public int LessonId { get; set; }
        public virtual Lesson? Lesson { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public string Content { get; set; }
        public string ImageComment { get; set; }
        public int? ParentCommentId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
