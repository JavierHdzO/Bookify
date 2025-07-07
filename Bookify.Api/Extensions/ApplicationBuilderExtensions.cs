using Bookify.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Api.Extensions;

public static  class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scoped = app.ApplicationServices.CreateScope();

        using var dbContext = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();

    }
}
