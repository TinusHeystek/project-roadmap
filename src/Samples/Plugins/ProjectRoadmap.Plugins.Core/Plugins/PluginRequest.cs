namespace ProjectRoadmap.Plugins.Core;

public class PluginRequest
{
    public string Type { get; set; }
    public string Question { get; set; }
    public object? Payload { get; set; }
    
    public PluginRequest(string type, string question, object? payload)
    {
        Type = type;
        Question = question;
        Payload = payload;
    }
}