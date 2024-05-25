using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.ResponseModels;

namespace TestMentor.Application.UseCases.User_UseCase.LoginUser
{
    public class LoginUserUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseLogin Data { get; set; }
    }
}
