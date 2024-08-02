using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectRoadmap.Plugins.Core;

public interface IPlugin
{
    void AddModule(IServiceCollection services, IConfiguration configuration);
    void RegisterModule(WebApplication app);
}