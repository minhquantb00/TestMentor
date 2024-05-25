using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Chapter_UseCase.DataChapter;

namespace TestMentor.Application.UseCases.Chapter_UseCase.GetChapterById
{
    public class GetChapterByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseChapter DataResponseChapter { get; set; }
    }
}
