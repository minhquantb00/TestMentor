using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;

namespace TestMentor.Application.UseCases.Lesson_UseCase.DataLesson
{
    public class LessonConverter
    {
        public DataResponseLesson EntityToDTO(Lesson lesson)
        {
            return new DataResponseLesson
            {
                CreateTime = lesson.CreateTime,
                Description = lesson.Description,
                Id = lesson.Id,
                LessonName = lesson.LessonName,
                LinkVideo = lesson.LinkVideo,
                VideoDuration = lesson.VideoDuration,
            };
        }
    }
}
