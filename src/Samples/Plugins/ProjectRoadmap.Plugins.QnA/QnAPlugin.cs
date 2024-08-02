using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRoadmap.Plugins.Core;

namespace ProjectRoadmap.Plugins.QnA;

public class QnAPlugin: IPlugin
{
    public static string Name => "QnA";

    public void AddModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddKeyedScoped<IPluginService, QnAService>(Name);
    }

    public void RegisterModule(WebApplication app)
    {
    }
}