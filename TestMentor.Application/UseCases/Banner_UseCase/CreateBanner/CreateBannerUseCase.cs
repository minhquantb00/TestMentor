using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.Handle.HandleImage;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;

namespace TestMentor.Application.UseCases.Banner_UseCase.CreateBanner
{
    public class CreateBannerUseCase : IUseCase<CreateBannerUseCaseInput, CreateBannerUseCaseOutput>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Banner> _bannerRepository;
        public CreateBannerUseCase(IHttpContextAccessor httpContextAccessor, IRepository<Banner> bannerRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _bannerRepository = bannerRepository;
        }

        public async Task<CreateBannerUseCaseOutput> ExcuteAsync(CreateBannerUseCaseInput input)
        {
            CreateBannerUseCaseOutput result = new CreateBannerUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    result.Errors = new string[] { "Người dùng chưa được xác thực" };
                    return result;
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                    return result;
                }
                Banner banner = new Banner
                {
                    IsActive = true,
                    ImageUrl = await HandleUploadImage.Upfile(input.File)
                };
                banner = await _bannerRepository.CreateAsync(banner);
                result.Succeeded = true;
                return result;
            }catch(Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<CreateBannerUseCaseOutput> ExcuteAsync(int? id, CreateBannerUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
