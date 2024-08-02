using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ProjectRoadmap.SemanticChat.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        var builder = Kernel.CreateBuilder();

        builder.AddAzureOpenAIChatCompletion(
            "gpt-35-turbo",                      // Azure OpenAI Deployment Name
            "https://contoso.openai.azure.com/", // Azure OpenAI Endpoint
            "...your Azure OpenAI Key...");      // Azure OpenAI Key
        
        return services;
    }
}