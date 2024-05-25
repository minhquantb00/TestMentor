using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.Handle.HandleImage;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Chapter_UseCase.CreateChapter
{
    public class CreaterChapterUseCase : IUseCase<CreateChapterUseCaseInput, CreateChapterUseCaseOutput>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<ChapterStudy> _chapterRepository;
        public CreaterChapterUseCase(IHttpContextAccessor httpContextAccessor, IRepository<Course> courseRepository, IRepository<ChapterStudy> chapterRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _courseRepository = courseRepository;
            _chapterRepository = chapterRepository;
        }

        public async Task<CreateChapterUseCaseOutput> ExcuteAsync(CreateChapterUseCaseInput input)
        {
            CreateChapterUseCaseOutput response = new CreateChapterUseCaseOutput
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
                var course = await _courseRepository.GetAsync(x => x.Id == input.CourseId);
                if (course == null)
                {
                    response.Errors = new string[] { "Khóa học không tồn tại" };
                    return response;
                }
                if (course.CreatorId != int.Parse(currentUser.FindFirst("Id").Value))
                {
                    response.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                    return response;
                }

                ChapterStudy chapterStudy = new ChapterStudy
                {
                    IsActive = true,
                    CourseId = input.CourseId,
                    CreateTime = DateTime.Now,
                    Image = input.Image == null ? "https://lotusacademy.edu.vn/api/media/download/551/ngon-ngu-lap-trinh-csharp-2.png" : await HandleUploadImage.Upfile(input.Image),
                    Name = input.Name,
                    TotalDuration = 0,
                    TotalLesson = 0
                };
                chapterStudy = await _chapterRepository.CreateAsync(chapterStudy);
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<CreateChapterUseCaseOutput> ExcuteAsync(int? id, CreateChapterUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
