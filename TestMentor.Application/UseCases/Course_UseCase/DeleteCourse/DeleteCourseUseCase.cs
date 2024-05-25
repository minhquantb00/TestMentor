using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Course_UseCase.DeleteCourse
{
    public class DeleteCourseUseCase : IUseCaseGetById<int, DeleteCourseUseCaseOutput>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Course> _courseRepository;
        public DeleteCourseUseCase(IHttpContextAccessor httpContextAccessor, IRepository<Course> courseRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _courseRepository = courseRepository;
        }

        public async Task<DeleteCourseUseCaseOutput> ExcuteAsync(int id)
        {
            DeleteCourseUseCaseOutput output = new DeleteCourseUseCaseOutput()
            {
                Succeeded = false
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            var userId = currentUser.FindFirst("Id").Value;
            var course = await _courseRepository.GetByIdAsync(id);
            if(course.CreatorId != int.Parse(userId))
            {
                output.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return output;
            }
            
            course.IsActive = false;
            await _courseRepository.UpdateAsync(course);
            output.Succeeded = true;
            return output;
        }
    }
}
