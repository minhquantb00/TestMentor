using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.ApplicationConstant;
using TestMentor.Application.Handle.HandleEmail;
using TestMentor.Application.InterfaceService;
using TestMentor.Domain.Entities;
using TestMentor.Domain.EnumeratesConstants;
using TestMentor.Domain.InterfaceRepository;
using TestMentor.Domain.Validate;
using BcryptNet = BCrypt.Net.BCrypt;

namespace TestMentor.Application.UseCases.User_UseCase.RegisterUser
{
    public class RegisterUserUseCase : IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ConfirmEmail> _confirmEmailRepository;
        private readonly IEmailService _emailService;
        public RegisterUserUseCase(IRepository<User> userRepository, IRepository<ConfirmEmail> confirmEmailRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _confirmEmailRepository = confirmEmailRepository;
            _emailService = emailService;
        }
        public async Task<RegisterUserUseCaseOutput> ExcuteAsync(RegisterUserUseCaseInput input)
        {
            var resultOutput = new RegisterUserUseCaseOutput
            {
                Succeeded = false,
            };
            try
            {
                if (!ValidateValue.IsValidEmail(input.Email))
                {
                    resultOutput.Errors = new string[] { $"Định dạng email không hợp lệ" };
                    return resultOutput;
                }
                if (!ValidateValue.IsValidPhoneNumber(input.PhoneNumber))
                {
                    resultOutput.Errors = new string[] { $"Định dạng số điện thoại không hợp lệ" };
                    return resultOutput;
                }
                if (_userRepository.GetUserByUsername(input.UserName).Result != null)
                {
                    resultOutput.Errors = new string[] { "Tài khoản đã tồn tại trên hệ thống" };
                    return resultOutput;
                }
                if (_userRepository.GetUserByPhoneNumber(input.PhoneNumber).Result != null)
                {
                    resultOutput.Errors = new string[] { "Số điện thoại đã tồn tại trên hệ thống" };
                    return resultOutput;
                }
                if (_userRepository.GetUserByEmail(input.Email).Result != null)
                {
                    resultOutput.Errors = new string[] { "Email đã tồn tại trên hệ thống" };
                    return resultOutput;
                }
                var user = new User
                {
                    UserName = input.UserName,
                    Password = BcryptNet.HashPassword(input.Password),
                    AvatarUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5zThKtjx7rImritWaiC62PPk65OYt70P7qA&usqp=CAU",
                    CreateTime = DateTime.Now,
                    Email = input.Email,
                    FullName = input.FullName,
                    Address = "",
                    Gender = input.Gender,
                    PhoneNumber = input.PhoneNumber,
                    UserStatusId = 1,
                    IsActive = true,
                };
                user = await _userRepository.CreateAsync(user);
                if (user.Id != null && user.Id != 0)
                {
                    await _userRepository.AddUserToRoleAsync(user, new string[] { "User" });

                    ConfirmEmail confirmEmail = new ConfirmEmail
                    {
                        ConfirmCode = Constant.GenerateCodeActive(),
                        ExpiryTime = DateTime.Now.AddMinutes(1),
                        IsConfirmed = false,
                        UserId = user.Id,
                    };
                    confirmEmail = await _confirmEmailRepository.CreateAsync(confirmEmail);
                    var message = new EmailMessage(new string[] { user.Email }, "Nhận mã xác nhận để kích hoạt tài khoản tại đây: ", $"Mã xác nhận là: {confirmEmail.ConfirmCode}");
                    _emailService.SendEmail(message);
                    resultOutput.Succeeded = true;
                    return resultOutput;
                }
                resultOutput.Errors = new string[] { "Đăng ký thất bại" };
                return resultOutput;
            }
            catch(Exception ex ) 
            {
                resultOutput.Errors = new string[] { ex.Message };
                resultOutput.Succeeded = false;
                return resultOutput;
            }
        }

        public Task<RegisterUserUseCaseOutput> ExcuteAsync(int? id, RegisterUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
