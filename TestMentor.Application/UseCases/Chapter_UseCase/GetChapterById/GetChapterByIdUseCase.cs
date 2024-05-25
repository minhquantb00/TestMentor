using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.UseCases.Chapter_UseCase.DataChapter;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Chapter_UseCase.GetChapterById
{
    public class GetChapterByIdUseCase : IUseCaseGetById<int, GetChapterByIdUseCaseOutput>
    {
        private readonly IRepository<ChapterStudy> _chapterStudyRepository;
        private readonly ChapterConverter _chapterConverter;
        public GetChapterByIdUseCase(IRepository<ChapterStudy> chapterStudyRepository, ChapterConverter chapterConverter)
        {
            _chapterStudyRepository = chapterStudyRepository;
            _chapterConverter = chapterConverter;
        }

        public async Task<GetChapterByIdUseCaseOutput> ExcuteAsync(int id)
        {
            GetChapterByIdUseCaseOutput response = new GetChapterByIdUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _chapterStudyRepository.GetAsync(x => x.Id == id);
            response.DataResponseChapter = _chapterConverter.EntityToDTO(query);
            response.Succeeded = true;
            return response;
        }
    }
}
