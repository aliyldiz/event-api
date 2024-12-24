using Event.Application.Abstractions.Services;
using Event.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITextService, TextService>();
        services.AddScoped<IFileService, FileService>();
    }
}