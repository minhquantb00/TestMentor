using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Course_UseCase.DataCourse;

namespace TestMentor.Application.UseCases.Course_UseCase.GetCouseById
{
    public class GetCourseByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseCourse DataResponseCourse { get; set; }
    }
}
