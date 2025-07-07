using Bookify.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Api.Extensions;

public static  class ApplicationBuilderExtensions
{
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        using var scoped = app.Services.CreateScope();
        using var dbContext = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        try 
        {

            await dbContext.Database.MigrateAsync();
            app.Logger.LogInformation("Database migrated successfully.");

        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "An error occurred while migrating the database.");
            throw;
        }
    }
}
