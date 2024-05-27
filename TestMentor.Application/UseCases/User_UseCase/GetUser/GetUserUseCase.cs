using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.User_UseCase.DataUser;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.User_UseCase.GetUser
{
    public class GetUserUseCase : IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserConverter _converter;
        public GetUserUseCase(IRepository<User> userRepository, UserConverter converter)
        {
            _userRepository = userRepository;
            _converter = converter;
        }

        public async Task<GetUserUseCaseOutput> ExcuteAsync(GetUserUseCaseInput input)
        {
            GetUserUseCaseOutput response = new GetUserUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _userRepository.GetAllAsync(record => record.IsActive == true);
            response.DataResponseUsers = query.Select(item => _converter.EntityToDTO(item));
            response.Succeeded = true;
            return response;
        }

        public Task<GetUserUseCaseOutput> ExcuteAsync(int? id, GetUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
