using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.User_UseCase.DataUser;

namespace TestMentor.Application.UseCases.User_UseCase.GetUserById
{
    public class GetUserByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseUser DataResponseUser { get; set; }
    }
}
