using Microsoft.Extensions.DependencyInjection;
using TwinCityCoders.Services.Test;

namespace TwinCityCoders.Services
{
    public static class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ITestService, TestService>();
        }
    }
}
