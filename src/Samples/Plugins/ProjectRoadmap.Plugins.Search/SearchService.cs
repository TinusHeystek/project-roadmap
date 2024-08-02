using ProjectRoadmap.Plugins.Core;

namespace ProjectRoadmap.Plugins.Search;

public class SearchService: IPluginService
{
    public Result<PluginResponse> Invoke(PluginRequest request)
    {
        return new PluginResponse(SearchPlugin.Name, $"Search: {request.Question}", []);
    }
}