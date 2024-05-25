using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Course_UseCase.DataCourse;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Course_UseCase.GetCourseByUserId
{
    public class GetCourseByUserIdUseCase : IUseCaseGetById<int, GetCourseByUserIdUseCaseOutput>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly CourseConverter _mapper;
        public GetCourseByUserIdUseCase(IRepository<Course> courseRepository, CourseConverter mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<GetCourseByUserIdUseCaseOutput> ExcuteAsync(int id)
        {
            GetCourseByUserIdUseCaseOutput response = new GetCourseByUserIdUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _courseRepository.GetAllAsync(record => record.CreatorId == id && record.IsActive == true);
            response.DataResponseCourses = query.Select(item => _mapper.EntityToDTO(item));
            response.Succeeded = true;
            return response;
        }
    }
}
