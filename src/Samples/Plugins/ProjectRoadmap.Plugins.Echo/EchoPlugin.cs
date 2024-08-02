using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRoadmap.Plugins.Core;

namespace ProjectRoadmap.Plugins.Echo;

public class EchoPlugin: IPlugin
{
    public static string Name => "Echo";

    public void AddModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddKeyedScoped<IPluginService, EchoService>(Name);
    }

    public void RegisterModule(WebApplication app)
    {
    }
}