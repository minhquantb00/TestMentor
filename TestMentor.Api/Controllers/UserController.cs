using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMentor.Application.ApplicationConstant;
using TestMentor.Application.UseCases;
using TestMentor.Application.UseCases.Banner_UseCase.GetBanner;
using TestMentor.Application.UseCases.Chapter_UseCase.CreateChapter;
using TestMentor.Application.UseCases.Chapter_UseCase.GetChapterById;
using TestMentor.Application.UseCases.Course_UseCase.DeleteCourse;
using TestMentor.Application.UseCases.Course_UseCase.GetCourse;
using TestMentor.Application.UseCases.Course_UseCase.GetCourseByUserId;
using TestMentor.Application.UseCases.Course_UseCase.GetCouseById;
using TestMentor.Application.UseCases.Course_UseCase.UpdateCourse;
using TestMentor.Application.UseCases.Lesson_UseCase.CreateLesson;
using TestMentor.Application.UseCases.User_UseCase.GetUser;

namespace TestMentor.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public UserController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse([FromQuery] GetCourseUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetCourseUseCaseInput, GetCourseUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByUserId([FromRoute] int id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<int, GetCourseByUserIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById([FromRoute] int id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<int, GetCourseByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<int, DeleteCourseUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if(!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateCourse([FromForm] UpdateCourseUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateCourseUseCaseInput, UpdateCourseUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateChapter([FromForm] CreateChapterUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateChapterUseCaseInput, CreateChapterUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateLesson([FromBody] CreateLessonUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateLessonUseCaseInput, CreateLessonUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChapterById([FromRoute] int id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<int, GetChapterByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBanners([FromQuery] GetBannerUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetBannerUseCaseInput, GetBannerUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
