using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProjectRoadmap.Plugins.Core;

namespace ProjectRoadmap.Plugins.Host.Extensions;

public static class PluginExtensions
{
    const string PluginNamespace = "ProjectRoadmap.Plugins";
    
    public static IServiceCollection AddPluginModules(this IServiceCollection services, IConfiguration configuration)
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var assemblies = Directory.GetFiles(baseDirectory, "*.dll")
            .Select(Assembly.LoadFrom)
            .Where(a => a.FullName != null && a.FullName.StartsWith(PluginNamespace))
            .ToArray();
        
        var plugins = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(type => type is { IsAbstract: false, IsInterface: false } 
                           && type.IsAssignableTo(typeof(IPlugin)))
            .Select(type => (IPlugin)Activator.CreateInstance(type)!)
            .ToList();
        
        foreach (var plugin in plugins)
        {
            plugin.AddModule(services, configuration);
        }
        
        services.TryAddEnumerable(plugins.Select(p => ServiceDescriptor.Transient(typeof(IPlugin), p.GetType())));
        return services;
    }

    public static IApplicationBuilder RegisterPluginModules(this WebApplication app)
    {
        var plugins = app.Services.GetRequiredService<IEnumerable<IPlugin>>();
        foreach (var plugin in plugins)
        {
            plugin.RegisterModule(app);
        }

        return app;
    }
}