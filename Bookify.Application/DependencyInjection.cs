using Bookify.Domain.Bookings;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        services.AddTransient<PricingService>();

        return services;
    }
}
