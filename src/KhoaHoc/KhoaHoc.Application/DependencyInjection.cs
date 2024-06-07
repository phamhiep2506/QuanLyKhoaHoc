using System.Reflection;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Application.Services;
using KhoaHoc.Application.Services.EmailServices;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IResponse, Response>();
        services.AddScoped<IUserRegisterService, UserRegisterService>();
        services.AddScoped<IConfirmEmailService, ConfirmEmailService>();

        return services;
    }
}
