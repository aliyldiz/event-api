using Event.Application.Abstractions.Services;
using Event.Persistence.DbContext;
using Event.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();
    }
}