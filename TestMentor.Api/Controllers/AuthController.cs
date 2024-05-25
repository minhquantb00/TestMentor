using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMentor.Application.ApplicationConstant;
using TestMentor.Application.UseCases.User_UseCase.RegisterUser;
using TestMentor.Application.UseCases;
using TestMentor.Application.UseCases.User_UseCase.LoginUser;
using TestMentor.Application.UseCases.User_UseCase.AuthenticateUser;
using TestMentor.Application.UseCases.User_UseCase.GetUserById;

namespace TestMentor.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public AuthController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> Register([FromForm] RegisterUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<LoginUserUseCaseInput, LoginUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<AuthenticateUserUseCaseInput, AuthenticateUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<int, GetUserByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
