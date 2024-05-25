using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.Handle.HandleImage;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Course_UseCase.CreateCourse
{
    public class CreateCourseUseCase : IUseCase<CreateCourseUseCaseInput, CreateCourseUseCaseOuput>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Course> _courseRepository;
        public CreateCourseUseCase(IHttpContextAccessor httpContextAccessor, IRepository<Course> courseRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _courseRepository = courseRepository;
        }

        public async Task<CreateCourseUseCaseOuput> ExcuteAsync(CreateCourseUseCaseInput input)
        {
            CreateCourseUseCaseOuput response = new CreateCourseUseCaseOuput
            {
                Succeeded = false
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    response.Errors = new string[] { "Người dùng chưa được xác thực" };
                    return response;
                }
                var course = new Course
                {
                    IsActive = true,
                    CourseTypeId = 1,
                    CreateTime = DateTime.Now,
                    CreatorId = int.Parse(currentUser.FindFirst("Id").Value),
                    Description = input.Description,
                    Image = input.Image == null ? "https://lotusacademy.edu.vn/api/media/download/551/ngon-ngu-lap-trinh-csharp-2.png" : await HandleUploadImage.Upfile(input.Image),
                    NumberOfCompleted = 0,
                    NumberOfSubcribers = 0,
                    Price = input.Price,
                    Title = input.Title,
                    TotalDuration = 0,
                    TotalLesson = 0,
                };
                course = await _courseRepository.CreateAsync(course);
                response.Succeeded = true;
                return response;
            }catch(Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<CreateCourseUseCaseOuput> ExcuteAsync(int? id, CreateCourseUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
