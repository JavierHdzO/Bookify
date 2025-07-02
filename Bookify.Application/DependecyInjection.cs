using Bookify.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Application;

public static class DependecyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });

        services.AddTransient<PricingService>();

        return services;
    }
}
