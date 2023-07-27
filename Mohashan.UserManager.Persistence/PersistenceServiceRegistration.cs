using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<UserManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("UserManagerConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IUserFeatureRepository, UserFeatureRepository>();
        services.AddScoped<IUserGroupRepository, UserGroupRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
