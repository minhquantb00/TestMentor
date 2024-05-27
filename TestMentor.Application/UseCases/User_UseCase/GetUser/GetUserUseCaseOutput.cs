using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.User_UseCase.DataUser;

namespace TestMentor.Application.UseCases.User_UseCase.GetUser
{
    public class GetUserUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseUser> DataResponseUsers { get; set; }
    }
}
