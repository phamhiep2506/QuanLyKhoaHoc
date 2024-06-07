namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services
    )
    {
        services.AddControllers();

        return services;
    }
}
