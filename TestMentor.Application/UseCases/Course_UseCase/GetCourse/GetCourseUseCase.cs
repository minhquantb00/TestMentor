using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Course_UseCase.DataCourse;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Course_UseCase.GetCourse
{
    public class GetCourseUseCase : IUseCase<GetCourseUseCaseInput, GetCourseUseCaseOutput>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly CourseConverter _mapper;
        public GetCourseUseCase(IRepository<Course> courseRepository, CourseConverter mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<GetCourseUseCaseOutput> ExcuteAsync(GetCourseUseCaseInput input)
        {
            GetCourseUseCaseOutput ouput = new GetCourseUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _courseRepository.GetAllAsync(record => record.IsActive == true);
            if (!string.IsNullOrEmpty(input.Title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(input.Title.ToLower()));
            }

            ouput.DataResponseCourse = query.Select(item => _mapper.EntityToDTO(item)).AsQueryable();
            ouput.Succeeded = true;
            return ouput;
        }

        public Task<GetCourseUseCaseOutput> ExcuteAsync(int? id, GetCourseUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
