using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Banner_UseCase.GetBanner
{
    public class GetBannerUseCase : IUseCase<GetBannerUseCaseInput, GetBannerUseCaseOutput>
    {
        private readonly IRepository<Banner> _bannerRepository;
        public GetBannerUseCase(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<GetBannerUseCaseOutput> ExcuteAsync(GetBannerUseCaseInput input)
        {
            GetBannerUseCaseOutput response = new GetBannerUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _bannerRepository.GetAllAsync(record => record.IsActive == true);
            response.DataResponseBanner = query;
            response.Succeeded = true;
            return response;
        }

        public Task<GetBannerUseCaseOutput> ExcuteAsync(int? id, GetBannerUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
