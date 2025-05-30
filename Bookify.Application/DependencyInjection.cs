﻿using Bookify.Application.Behaviors;
using Bookify.Domain.Bookings;
using FluentValidation;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddMediatR(configuration => 
        {
            configuration.RegisterServicesFromAssembly(AssemblyReference.Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);

        services.AddTransient<PricingService>();

        return services;
    }
}
