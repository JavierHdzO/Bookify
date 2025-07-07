using Bookify.Application;
using Bookify.Infrastructure;
using Bookify.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ApplyMigrations();
    
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
