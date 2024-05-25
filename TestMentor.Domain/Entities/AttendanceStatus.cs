using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class AttendanceStatus : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
