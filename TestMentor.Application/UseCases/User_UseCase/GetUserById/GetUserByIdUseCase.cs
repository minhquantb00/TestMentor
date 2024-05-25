using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.User_UseCase.DataUser;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.User_UseCase.GetUserById
{
    public class GetUserByIdUseCase : IUseCaseGetById<int, GetUserByIdUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserConverter _mapper;
        public GetUserByIdUseCase(IRepository<User> userRepository, UserConverter mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdUseCaseOutput> ExcuteAsync(int id)
        {
            GetUserByIdUseCaseOutput response = new GetUserByIdUseCaseOutput
            {
                Succeeded = false
            };
            var user = await _userRepository.GetByIdAsync(id);
            response.DataResponseUser = _mapper.EntityToDTO(user);
            response.Succeeded = true;
            return response;
        }
    }
}
