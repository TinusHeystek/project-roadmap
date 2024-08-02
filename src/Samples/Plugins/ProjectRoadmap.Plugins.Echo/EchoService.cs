using ProjectRoadmap.Plugins.Core;

namespace ProjectRoadmap.Plugins.Echo;

public class EchoService: IPluginService
{
    public Result<PluginResponse> Invoke(PluginRequest request)
    {
        return new PluginResponse(EchoPlugin.Name, $"Echo: {request.Question}", []);
    }
}