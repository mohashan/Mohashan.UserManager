using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mohashan.UserManager.Application.Contracts.Infrastructure;
using Mohashan.UserManager.Application.Models.Mail;
using Mohashan.UserManager.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
