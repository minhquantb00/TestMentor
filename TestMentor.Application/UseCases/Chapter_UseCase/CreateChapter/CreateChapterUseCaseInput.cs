using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;

namespace TestMentor.Application.UseCases.Chapter_UseCase.CreateChapter
{
    public class CreateChapterUseCaseInput
    {
        public string Name { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }
        public int CourseId { get; set; }
    }
}
