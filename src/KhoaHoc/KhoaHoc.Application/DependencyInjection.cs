using System.Reflection;
using System.Text;
using KhoaHoc.Application.Helpers;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.ICreateRefreshTokenServices;
using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Application.Services.EmailServices;
using KhoaHoc.Application.Services.RefreshTokenServices;
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
        services.AddScoped<IUserRegisterService, UserRegisterService>();
        services.AddScoped<IConfirmEmailService, ConfirmEmailService>();
        services.AddScoped<IUserLoginService, UserLoginService>();
        services.AddScoped<
            ICreateRefreshTokenService,
            CreateRefreshTokenService
        >();
        services.AddScoped<IJsonWebToken, JsonWebToken>();
        services.AddScoped<ISendEmailService, SendEmailService>();
        services.AddScoped<IUserPasswordService, UserPasswordService>();

        return services;
    }
}
