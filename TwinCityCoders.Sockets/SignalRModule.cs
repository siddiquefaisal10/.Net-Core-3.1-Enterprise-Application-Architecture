using Microsoft.Extensions.DependencyInjection;
using TwinCityCoders.Sockets.TestMessage;

namespace TwinCityCoders.Sockets
{
    public static class SignalRModule
    {
        public static void SignalR(IServiceCollection services)
        {
            services.AddSingleton<ITestMessageCounter, TestMessageCounter>();
        }
    }
}
