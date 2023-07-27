using Infrastructure.Data.Contexts;
using KidsBazaar.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
var dbcontext = service.GetService<StoreContext>();
var logger = service.GetService<ILogger<Program>>();

try
{
    await dbcontext.Database.MigrateAsync();
    await SeedContext.SeedAsync(dbcontext);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error has ocurred during migration");
}

app.Run();
