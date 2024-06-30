using System.Reflection;
using System.Text;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.ICourseServices;
using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Application.Interfaces.IJwtServices;
using KhoaHoc.Application.Interfaces.IPermissionServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Application.Services.CourseServices;
using KhoaHoc.Application.Services.EmailServices;
using KhoaHoc.Application.Services.JwtServices;
using KhoaHoc.Application.Services.PermissionServices;
using KhoaHoc.Application.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddAuthorization();
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                    new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                configuration["Jwt:SecretKey"]!
                            )
                        )
                    };
            });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IResponse, Response>();
        services.AddScoped<IUserLoginService, UserLoginService>();
        services.AddScoped<IUserRegisterService, UserRegisterService>();
        services.AddScoped<IUserPasswordService, UserPasswordService>();
        services.AddScoped<IConfirmEmailService, ConfirmEmailService>();
        services.AddScoped<ISendEmailService, SendEmailService>();
        services.AddScoped<IJwtAccessTokenService, JwtAccessTokenService>();
        services.AddScoped<IJwtRefreshTokenService, JwtRefreshTokenService>();
        services.AddScoped<ICreatePermissionService, CreatePermissionService>();
        services.AddScoped<IUserUpdateService, UserUpdateService>();
        services.AddScoped<IUserGetService, UserGetService>();
        services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
        services.AddScoped<ICreateCourceService, CreateCourceService>();

        return services;
    }
}
