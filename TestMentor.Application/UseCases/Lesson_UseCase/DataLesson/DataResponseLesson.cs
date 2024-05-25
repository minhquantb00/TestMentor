using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;

namespace TestMentor.Application.UseCases.Lesson_UseCase.DataLesson
{
    public class DataResponseLesson
    {
        public int Id { get; set; } 
        public string LessonName { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string LinkVideo { get; set; }
        public int VideoDuration { get; set; }
    }
}
