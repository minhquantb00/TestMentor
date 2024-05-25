using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Application.UseCases
{
    public interface IUseCaseGetById<T, TUseCaseOutput> where TUseCaseOutput : class
    {
        Task<TUseCaseOutput> ExcuteAsync(T id);
    }
}
