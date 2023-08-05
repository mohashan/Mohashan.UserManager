﻿using Microsoft.EntityFrameworkCore;
using Mohashan.UserManager.Application;
using Mohashan.UserManager.Infrastructure;
using Mohashan.UserManager.Persistence;

namespace Mohashan.UserManager.API;
public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Open",builder=>builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        //app.UseHttpsRedirection();
        app.UseRouting();

        app.UseCors("Open");

        app.MapControllers();

        return app;
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<UserManagerDbContext>();
            if(context != null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
