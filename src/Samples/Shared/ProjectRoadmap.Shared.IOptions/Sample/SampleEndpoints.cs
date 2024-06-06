using Microsoft.Extensions.Options;

namespace ProjectRoadmap.Shared.IOptions.Sample;

public static class OptionEndpoints
{
    public static void RegisterOptionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/sample-settings", (IOptions<SampleSettings> options) => options)
            .WithName("SampleSettings")
            .WithOpenApi();
        
        app.MapGet("/sample-annotation-settings", (IOptions<SampleAnnotationSettings> options) => options)
            .WithName("SampleAnnotationSettings")
            .WithOpenApi();
    }
}