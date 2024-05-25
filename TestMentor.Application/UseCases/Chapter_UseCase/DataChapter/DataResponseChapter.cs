using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Lesson_UseCase.DataLesson;
using TestMentor.Domain.Entities;

namespace TestMentor.Application.UseCases.Chapter_UseCase.DataChapter
{
    public class DataResponseChapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalDuration { get; set; }
        public int TotalLesson { get; set; }
        public string Image { get; set; }
        public DateTime CreateTime { get; set; }
        public IQueryable<DataResponseLesson> Lessons { get; set; }
    }
}
