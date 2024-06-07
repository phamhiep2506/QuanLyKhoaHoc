using System.Reflection;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IResponse, Response>();

        return services;
    }
}
