using ProjectRoadmap.Plugins.Core;

namespace ProjectRoadmap.Plugins.QnA;

public class QnAService: IPluginService
{
    public Result<PluginResponse> Invoke(PluginRequest request)
    {
        return new PluginResponse(QnAPlugin.Name, $"QnA: {request.Question}", []);
    }
}