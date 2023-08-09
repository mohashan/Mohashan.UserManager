using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        try
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
        catch (ReflectionTypeLoadException ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Exception exSub in ex.LoaderExceptions)
            {
                sb.AppendLine(exSub.Message);
                FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                if (exFileNotFound != null)
                {
                    if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                    {
                        sb.AppendLine("Fusion Log:");
                        sb.AppendLine(exFileNotFound.FusionLog);
                    }
                }
                sb.AppendLine();
            }
            string errorMessage = sb.ToString();
            //Display or log the error based on your application.
        }
        

        return services;
    }
}
