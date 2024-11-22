using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using MarkSetBotAlpha.Module.MarkSetBotWWW.Repository;
using MarkSetBotAlpha.Module.MarkSetBotWWW.Services;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Startup
{
    public class ServerStartup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // not implemented
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            // not implemented
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMarkSetBotWWWService, ServerMarkSetBotWWWService>();
            services.AddDbContextFactory<MarkSetBotWWWContext>(opt => { }, ServiceLifetime.Transient);
        }
    }
}
