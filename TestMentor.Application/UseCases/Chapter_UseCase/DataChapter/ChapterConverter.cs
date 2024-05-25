using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Lesson_UseCase.DataLesson;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Chapter_UseCase.DataChapter
{
    public class ChapterConverter
    {
        private readonly IRepository<Lesson> _lessonRepository;
        private LessonConverter _mapper;
        public ChapterConverter(IRepository<Lesson> lessonRepository, LessonConverter mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }
        public DataResponseChapter EntityToDTO(ChapterStudy chapter)
        {
            return new DataResponseChapter
            {
                CreateTime = chapter.CreateTime,
                Id = chapter.Id,
                Image = chapter.Image,
                Lessons = _lessonRepository.GetAllAsync(x => x.IsActive == true && x.ChapterId == chapter.Id).Result.Select(item => _mapper.EntityToDTO(item)),
                Name = chapter.Name,
                TotalDuration = chapter.TotalDuration,
                TotalLesson = chapter.TotalLesson,
            };
        }
    }
}
