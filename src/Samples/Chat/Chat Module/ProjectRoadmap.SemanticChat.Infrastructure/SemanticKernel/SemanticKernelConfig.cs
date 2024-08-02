namespace ProjectRoadmap.SemanticChat.Infrastructure.SemanticKernel;

public class SemanticKernelConfig
{
    public const string Section = "SemanticKernel";
    public AzureOpenAiConfig OpenAiConfig { get; private set; } = new();
    public AzureAiSearchConfig AiSearchConfig { get; private set; } = new();
}

public class AzureOpenAiConfig
{
    public string Endpoint { get; private set; } = string.Empty;
    public string Key { get; private set; } = string.Empty;
    public string Model { get; private set; } = string.Empty;
}

public class AzureAiSearchConfig
{
    public string Endpoint { get; private set; } = string.Empty;
    public string Key { get; private set; } = string.Empty;
    public string Index { get; private set; } = string.Empty;
}