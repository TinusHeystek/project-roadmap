using ProjectRoadmap.Plugins.Core;

namespace ProjectRoadmap.Plugins.Host.Messages;

internal sealed class SendMessage : IEndpoint
{
    private const string Tag = "Messages";
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/message/{type}/{message}", 
                async (string type, string messages, IServiceProvider serviceProvider) =>
            {
                var plugin = serviceProvider.GetRequiredKeyedService<IPluginService>(type);

                var result = plugin.Invoke(new PluginRequest(type, messages, null));
                return result.Match(() => Results.Ok(result.Value), ApiResults.Problem);
            })
            .WithTags(Tag);
    }
}