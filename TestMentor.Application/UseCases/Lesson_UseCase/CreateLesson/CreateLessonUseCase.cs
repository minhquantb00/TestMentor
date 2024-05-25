using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Lesson_UseCase.CreateLesson
{
    public class CreateLessonUseCase : IUseCase<CreateLessonUseCaseInput, CreateLessonUseCaseOutput>
    {
        private readonly IRepository<Lesson> _lessonRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<ChapterStudy> _chapterRepository;
        private readonly IRepository<Course> _courseRepository;
        public CreateLessonUseCase(IRepository<Lesson> lessonRepository, IHttpContextAccessor httpContextAccessor, IRepository<ChapterStudy> chapterRepository, IRepository<Course> courseRepository)
        {
            _lessonRepository = lessonRepository;
            _httpContextAccessor = httpContextAccessor;
            _chapterRepository = chapterRepository;
            _courseRepository = courseRepository;
        }

        public async Task<CreateLessonUseCaseOutput> ExcuteAsync(CreateLessonUseCaseInput input)
        {
            CreateLessonUseCaseOutput response = new CreateLessonUseCaseOutput
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
                var chapter = await _chapterRepository.GetAsync(record => record.Id == input.ChapterId);
                if(chapter == null)
                {
                    response.Errors = new string[] { "Chương học không tồn tại" };
                    return response;
                }
                var course = await _courseRepository.GetAsync(record => record.Id == chapter.CourseId);
                if (course.CreatorId != int.Parse(currentUser.FindFirst("Id").Value))
                {
                    response.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                    return response;
                }

                Lesson lesson = new Lesson
                {
                    IsActive = true,
                    ChapterId = input.ChapterId,
                    CreateTime = DateTime.Now,
                    Description = input.Description,
                    LessonName = input.LessonName,
                    LessonStatusId = 1,
                    LinkVideo = input.LinkVideo,
                    VideoDuration = input.VideoDuration,
                };
                lesson = await _lessonRepository.CreateAsync(lesson);
                chapter.TotalDuration += lesson.VideoDuration;
                chapter.TotalLesson += 1;
                await _chapterRepository.UpdateAsync(chapter);
                course.TotalDuration = chapter.TotalDuration;
                course.TotalLesson = chapter.TotalLesson;
                await _courseRepository.UpdateAsync(course);

                response.Succeeded = true;
                return response;
            }catch(Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<CreateLessonUseCaseOutput> ExcuteAsync(int? id, CreateLessonUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
