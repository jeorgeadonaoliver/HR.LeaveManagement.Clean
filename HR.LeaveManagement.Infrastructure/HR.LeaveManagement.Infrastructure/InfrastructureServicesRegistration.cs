using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection
         services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IAppLoggers<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
