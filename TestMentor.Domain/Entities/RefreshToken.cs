﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
