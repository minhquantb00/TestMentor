using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMentor.Application.UseCases.Banner_UseCase.CreateBanner
{
    public class CreateBannerUseCaseInput
    {
        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
    }
}
