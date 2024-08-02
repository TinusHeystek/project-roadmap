using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRoadmap.Plugins.Core;

namespace ProjectRoadmap.Plugins.Search;

public class SearchPlugin: IPlugin
{
    public static string Name => "Search";

    public void AddModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddKeyedScoped<IPluginService, SearchService>(Name);
    }

    public void RegisterModule(WebApplication app)
    {
    }
}