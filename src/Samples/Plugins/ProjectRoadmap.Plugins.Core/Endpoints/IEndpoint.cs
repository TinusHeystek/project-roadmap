using Microsoft.AspNetCore.Routing;

namespace ProjectRoadmap.Plugins.Core;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}