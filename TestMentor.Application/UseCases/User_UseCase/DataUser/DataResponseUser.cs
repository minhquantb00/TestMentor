using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.EnumeratesConstants;

namespace TestMentor.Application.UseCases.User_UseCase.DataUser
{
    public class DataResponseUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
