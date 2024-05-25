using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;

namespace TestMentor.Application.UseCases.User_UseCase.DataUser
{
    public class UserConverter
    {
        public DataResponseUser EntityToDTO(User user)
        {
            return new DataResponseUser
            {
                Id = user.Id,
                Address = user.Address,
                AvatarUrl = user.AvatarUrl,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender.ToString(),
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}
