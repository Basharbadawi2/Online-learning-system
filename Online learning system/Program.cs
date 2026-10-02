using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Online_learning_system.Data;
using Online_learning_system.Repositories;
using Online_learning_system.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<OnlineLearningDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Services
builder.Services.AddSingleton<PasswordResetService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IModuleRepository, ModuleRepository>();

builder.Services.AddScoped<IModuleService, ModuleService>();

builder.Services.AddScoped<IEnrollmentRepository,EnrollmentRepository>();

builder.Services.AddScoped<IEnrollmentService,EnrollmentService>();

builder.Services.AddScoped<IQuizRepository, QuizRepository>();

builder.Services.AddScoped<IQuizService, QuizService>();

builder.Services.AddScoped<IQuestionRepository,QuestionRepository>();

builder.Services.AddScoped<IQuestionService,QuestionService>();

builder.Services.AddScoped<IAnswerOptionRepository,AnswerOptionRepository>();

builder.Services.AddScoped<IAnswerOptionService,AnswerOptionService>();

builder.Services.AddScoped<IQuizAttemptRepository,QuizAttemptRepository>();

builder.Services.AddScoped<IQuizAttemptService,QuizAttemptService>();

builder.Services.AddScoped<IPaymentRepository,PaymentRepository>();

builder.Services.AddScoped<IPaymentService,PaymentService>();

builder.Services.AddScoped<ICertificateRepository,CertificateRepository>();

builder.Services.AddScoped<ICertificateService,CertificateService>();

builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

builder.Services.AddScoped<IInstructorService, InstructorService>();

builder.Services.AddScoped<ILessonRepository, LessonRepository>();

builder.Services.AddScoped<ILessonService, LessonService>();

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// JWT Authentication
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!))
            };
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();