using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestMentor.Domain.EnumeratesConstants
{
    public class Enumerates
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum SchoolShirt
        {
            Ca1 = 0,
            Ca2 = 1,
            Ca3 = 2
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum AttendanceStatus
        {
            Vang = 0,
            DaDen = 1,
            XinNghi = 2
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Gender
        {
            Male = 0,
            Female = 1
        }
        public enum UserStatus
        {
            UnActivated = 0,
            Activated = 1
        }
        public enum Role
        {
            Admin = 0,
            Mentor = 1,
            Student = 2,
        }
    }
}
