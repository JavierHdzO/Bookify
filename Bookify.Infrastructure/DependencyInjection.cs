using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Bookify.Application.Abstractions.Clock;
using Bookify.Infrastructure.Clock;
using Bookify.Application.Abstractions.Email;
using Bookify.Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
using Bookify.Domain.Users;
using Bookify.Infrastructure.Repositories;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Abstractions;
using Bookify.Application.Abstractions.Data;
using Bookify.Infrastructure.Data;
using Dapper;

namespace Bookify.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) 
    {

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IEmailService, EmailService>();

        string connectionString =
            configuration.GetConnectionString("BookifyDataBase")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddSqlConnectionProvider(connectionString);

        services.AddDbContext(connectionString);   

        services.AddRepositories();  
        
        services.AddUnitOfWork();   

        return services;
    }

    public static void AddSqlConnectionProvider(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<ISqlConnectionFactory>( _ => new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
    }

    private static void AddDbContext(
        this IServiceCollection services,
        string connectionString) 
    {

        services.AddDbContext<ApplicationDbContext>(options => 
        {
            options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });
        
        
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApartmentRepository, ApartmentRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();

    }

    private static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
    }



}
