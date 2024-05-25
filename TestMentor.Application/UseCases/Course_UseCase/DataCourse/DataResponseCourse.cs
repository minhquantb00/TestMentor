using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Chapter_UseCase.DataChapter;
using TestMentor.Domain.Entities;

namespace TestMentor.Application.UseCases.Course_UseCase.DataCourse
{
    public class DataResponseCourse
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string CreatorName { get; set; }
        public string AvatarUser { get; set; }
        public DateTime CreateTime { get; set; }
        public int TotalDuration { get; set; }
        public int NumberOfSubcribers { get; set; }
        public int NumberOfCompleted { get; set; }
        public int TotalLesson { get; set; }
        public IQueryable<DataResponseChapter> DataResponseChapters { get; set; }
    }
}
