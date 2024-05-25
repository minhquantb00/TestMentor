using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Course_UseCase.DataCourse;
using TestMentor.Domain.Entities;

namespace TestMentor.Application.UseCases.Course_UseCase.GetCourse
{
    public class GetCourseUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseCourse> DataResponseCourse { get; set; }
    }
}
