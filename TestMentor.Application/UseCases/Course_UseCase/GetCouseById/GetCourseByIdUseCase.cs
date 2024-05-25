using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Course_UseCase.DataCourse;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Course_UseCase.GetCouseById
{
    public class GetCourseByIdUseCase : IUseCaseGetById<int, GetCourseByIdUseCaseOutput>
    {
        private readonly IRepository<Course> _repository;
        private readonly CourseConverter _mapper;
        public GetCourseByIdUseCase(IRepository<Course> repository, CourseConverter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCourseByIdUseCaseOutput> ExcuteAsync(int id)
        {
            GetCourseByIdUseCaseOutput response = new GetCourseByIdUseCaseOutput
            {
                Succeeded = true,
                DataResponseCourse = _mapper.EntityToDTO(await _repository.GetAsync(item => item.Id == id)),
            };
            return response;
        }
    }
}
