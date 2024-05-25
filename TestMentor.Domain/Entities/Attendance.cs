using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.EnumeratesConstants;

namespace TestMentor.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public int LessonId { get; set; }
        public virtual Lesson? Lesson { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule? Schedule { get; set;}
        public int AttendanceStatusId { get; set; }
        public virtual AttendanceStatus? AttendanceStatus { get; set; }
        public Enumerates.SchoolShirt? SchoolShirt { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
