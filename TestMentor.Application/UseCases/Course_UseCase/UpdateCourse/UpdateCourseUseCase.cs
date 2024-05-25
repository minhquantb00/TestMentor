using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.Handle.HandleImage;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Course_UseCase.UpdateCourse
{
    public class UpdateCourseUseCase : IUseCase<UpdateCourseUseCaseInput, UpdateCourseUseCaseOutput>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Course> _courseRepository;
        public UpdateCourseUseCase(IHttpContextAccessor httpContextAccessor, IRepository<Course> courseRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _courseRepository = courseRepository;
        }

        public async Task<UpdateCourseUseCaseOutput> ExcuteAsync(UpdateCourseUseCaseInput input)
        {
            UpdateCourseUseCaseOutput response = new UpdateCourseUseCaseOutput
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
                var course = await _courseRepository.GetAsync(record => record.Id == input.Id);
                if(course.CreatorId != int.Parse(currentUser.FindFirst("Id").Value))
                {
                    response.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                    return response;
                }

                course.Title = input.Title;
                course.Description = input.Title;
                course.Price = input.Price;
                course.Image = input.Image == null ? "https://lotusacademy.edu.vn/api/media/download/551/ngon-ngu-lap-trinh-csharp-2.png" : await HandleUploadImage.Upfile(input.Image);
                course.UpdateTime = DateTime.Now;
                await _courseRepository.UpdateAsync(course);
                response.Succeeded = true;
                return response;
            }
            catch(Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<UpdateCourseUseCaseOutput> ExcuteAsync(int? id, UpdateCourseUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
