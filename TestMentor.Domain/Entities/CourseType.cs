using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class CourseType : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
