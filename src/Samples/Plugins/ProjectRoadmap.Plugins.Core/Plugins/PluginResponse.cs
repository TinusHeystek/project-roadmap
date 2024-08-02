namespace ProjectRoadmap.Plugins.Core;

public class PluginResponse
{
    public string Type { get; set; }
    public string Answer { get; set; }
    public List<string> Sources { get; set; }
    
    public PluginResponse(string type, string answer, List<string> sources)
    {
        Type = type;
        Answer = answer;
        Sources = sources;
    }
}