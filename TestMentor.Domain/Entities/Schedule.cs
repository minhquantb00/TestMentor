using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.EnumeratesConstants;

namespace TestMentor.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public int StudentId { get; set; }
        public virtual User? Student { get; set; }
        public Enumerates.SchoolShirt SchoolShirt { get; set; }
        public int Day { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }
    }
}
