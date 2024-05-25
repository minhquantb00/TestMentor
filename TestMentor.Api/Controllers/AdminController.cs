using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMentor.Application.ApplicationConstant;
using TestMentor.Application.UseCases;
using TestMentor.Application.UseCases.Course_UseCase.CreateCourse;

namespace TestMentor.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public AdminController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateCourse([FromForm] CreateCourseUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateCourseUseCaseInput, CreateCourseUseCaseOuput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
