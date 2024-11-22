using Microsoft.Extensions.DependencyInjection;
using Oqtane.Services;
using MarkSetBotAlpha.Module.MarkSetBotWWW.Services;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Startup
{
    public class ClientStartup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMarkSetBotWWWService, MarkSetBotWWWService>();
        }
    }
}
