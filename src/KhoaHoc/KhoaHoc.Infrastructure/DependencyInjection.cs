using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;
using KhoaHoc.Infrastructure.Interfaces;
using KhoaHoc.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString(
            "DefaultConnection"
        );

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
        );

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<IRepository<User>, Repository<User>>();
        services.AddScoped<
            IRepository<ConfirmEmail>,
            Repository<ConfirmEmail>
        >();

        return services;
    }
}
