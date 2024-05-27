using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;

namespace TestMentor.Application.UseCases.Banner_UseCase.GetBanner
{
    public class GetBannerUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<Banner> DataResponseBanner { get; set; }
    }
}
