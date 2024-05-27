using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SixLabors.ImageSharp;
using System.Text;
using TestMentor.Application.Handle.HandleEmail;
using TestMentor.Application.ImplementService;
using TestMentor.Application.InterfaceService;
using TestMentor.Application.UseCases.User_UseCase.LoginUser;
using TestMentor.Application.UseCases.User_UseCase.RegisterUser;
using TestMentor.Application.UseCases;
using TestMentor.Domain.Entities;
using TestMentor.Domain.InterfaceRepository;
using TestMentor.Infrastructure.DataContext;
using TestMentor.Infrastructure.ImplementRepository;
using TestMentor.Application.UseCases.User_UseCase.AuthenticateUser;
using TestMentor.Application.UseCases.User_UseCase.GetUserById;
using TestMentor.Application.UseCases.User_UseCase.DataUser;
using TestMentor.Application.UseCases.Course_UseCase.CreateCourse;
using TestMentor.Application.UseCases.Course_UseCase.DataCourse;
using TestMentor.Application.UseCases.Course_UseCase.GetCourse;
using TestMentor.Application.UseCases.Course_UseCase.GetCourseByUserId;
using TestMentor.Application.UseCases.Course_UseCase.DeleteCourse;
using TestMentor.Application.UseCases.Course_UseCase.GetCouseById;
using TestMentor.Application.UseCases.Course_UseCase.UpdateCourse;
using TestMentor.Application.UseCases.Chapter_UseCase.CreateChapter;
using TestMentor.Application.UseCases.Chapter_UseCase.DataChapter;
using TestMentor.Application.UseCases.Lesson_UseCase.DataLesson;
using TestMentor.Application.UseCases.Lesson_UseCase.CreateLesson;
using TestMentor.Application.UseCases.Chapter_UseCase.GetChapterById;
using TestMentor.Application.UseCases.Banner_UseCase.CreateBanner;
using TestMentor.Application.UseCases.Banner_UseCase.GetBanner;
using TestMentor.Application.UseCases.User_UseCase.GetUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder
            .WithOrigins("http://localhost:8080", "http://localhost:4200", "http://localhost:5174", "http://localhost:5173")
            .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});

#region Register IUseCase
builder.Services.AddScoped<IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>, RegisterUserUseCase>();
builder.Services.AddScoped<IUseCase<LoginUserUseCaseInput, LoginUserUseCaseOutput>, LoginUserUseCase>();
builder.Services.AddScoped<IUseCase<AuthenticateUserUseCaseInput, AuthenticateUserUseCaseOutput>, AuthenticateUserUseCase>();
builder.Services.AddScoped<IUseCaseGetById<int, GetUserByIdUseCaseOutput>, GetUserByIdUseCase>();
builder.Services.AddScoped<IUseCase<CreateCourseUseCaseInput, CreateCourseUseCaseOuput>, CreateCourseUseCase>();
builder.Services.AddScoped<IUseCase<GetCourseUseCaseInput, GetCourseUseCaseOutput>, GetCourseUseCase>();
builder.Services.AddScoped<IUseCaseGetById<int, GetCourseByUserIdUseCaseOutput>, GetCourseByUserIdUseCase>();
builder.Services.AddScoped<IUseCaseGetById<int, DeleteCourseUseCaseOutput>, DeleteCourseUseCase>();
builder.Services.AddScoped<IUseCaseGetById<int, GetCourseByIdUseCaseOutput>, GetCourseByIdUseCase>();
builder.Services.AddScoped<IUseCase<UpdateCourseUseCaseInput, UpdateCourseUseCaseOutput>, UpdateCourseUseCase>();
builder.Services.AddScoped<IUseCase<CreateChapterUseCaseInput, CreateChapterUseCaseOutput>, CreaterChapterUseCase>();
builder.Services.AddScoped<IUseCase<CreateLessonUseCaseInput, CreateLessonUseCaseOutput>, CreateLessonUseCase>();
builder.Services.AddScoped<IUseCaseGetById<int, GetChapterByIdUseCaseOutput>, GetChapterByIdUseCase>();
builder.Services.AddScoped<IUseCase<CreateBannerUseCaseInput, CreateBannerUseCaseOutput>, CreateBannerUseCase>();
builder.Services.AddScoped<IUseCase<GetBannerUseCaseInput, GetBannerUseCaseOutput>, GetBannerUseCase>();
builder.Services.AddScoped<IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>, GetUserUseCase>();
#endregion

#region Register Repository
builder.Services.AddScoped<IDbContext, AppDbContext>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Permission>, Repository<Permission>>();
builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
builder.Services.AddScoped<IRepository<RefreshToken>, Repository<RefreshToken>>();
builder.Services.AddScoped<IRepository<ConfirmEmail>, Repository<ConfirmEmail>>();
builder.Services.AddScoped<IRepository<Course>, Repository<Course>>();
builder.Services.AddScoped<IRepository<ChapterStudy>, Repository<ChapterStudy>>();
builder.Services.AddScoped<IRepository<Lesson>, Repository<Lesson>>();
builder.Services.AddScoped<IRepository<ChapterStudy>, Repository<ChapterStudy>>();
builder.Services.AddScoped<IRepository<Banner>, Repository<Banner>>();
#endregion

#region Đăng ký service
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IEmailService, EmailService>();
#endregion

#region Register Mapper
builder.Services.AddScoped<UserConverter>();
builder.Services.AddScoped<CourseConverter>();
builder.Services.AddScoped<ChapterConverter>();
builder.Services.AddScoped<LessonConverter>();
#endregion

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromMinutes(5);
});

builder.Services.Configure<IdentityOptions>(
    opts => opts.SignIn.RequireConfirmedEmail = true
    );

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
