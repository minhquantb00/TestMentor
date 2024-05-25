using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class ConfirmEmail : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public string ConfirmCode { get; set; }
        public DateTime? ExpiryTime { get; set; }
        public bool IsConfirmed { get; set; } = false;
    }
}
