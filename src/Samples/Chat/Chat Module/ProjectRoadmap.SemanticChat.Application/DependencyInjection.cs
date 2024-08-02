using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectRoadmap.SemanticChat.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));

            //options.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            // options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            //options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

        return services;
    }
}