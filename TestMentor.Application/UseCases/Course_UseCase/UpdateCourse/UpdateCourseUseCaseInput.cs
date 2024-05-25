using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Application.UseCases.Course_UseCase.UpdateCourse
{
    public class UpdateCourseUseCaseInput
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }
    }
}
