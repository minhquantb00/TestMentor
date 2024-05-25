using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Chapter_UseCase.DataChapter;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Course_UseCase.DataCourse
{
    public class CourseConverter
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ChapterStudy> _chapterStudyRepository;
        private readonly ChapterConverter _chapterConverter;
        public CourseConverter(IRepository<User> userRepository, IRepository<ChapterStudy> chapterStudyRepository, ChapterConverter chapterConverter)
        {
            _userRepository = userRepository;
            _chapterStudyRepository = chapterStudyRepository;
            _chapterConverter = chapterConverter;
        }
        public DataResponseCourse EntityToDTO(Course entity)
        {
            return new DataResponseCourse()
            {
                CreateTime = entity.CreateTime,
                CreatorName = _userRepository.GetAsync(record => record.Id == entity.CreatorId).Result.FullName,
                Description = entity.Description,
                Id = entity.Id,
                Image = entity.Image,
                NumberOfCompleted = entity.NumberOfCompleted,
                NumberOfSubcribers = entity.NumberOfSubcribers,
                Price = entity.Price,
                Title = entity.Title,
                TotalDuration = entity.TotalDuration,
                TotalLesson = entity.TotalLesson,
                AvatarUser = _userRepository.GetAsync(record => record.Id == entity.CreatorId).Result.AvatarUrl,
                DataResponseChapters = _chapterStudyRepository.GetAllAsync(x =>  x.IsActive == true && x.CourseId == entity.Id).Result.Select(item => _chapterConverter.EntityToDTO(item))
            };
        }
    }
}
