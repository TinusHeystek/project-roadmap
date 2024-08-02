namespace ProjectRoadmap.Plugins.Core;

public interface IPluginService
{
    Result<PluginResponse> Invoke(PluginRequest request);
}