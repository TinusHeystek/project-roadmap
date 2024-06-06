namespace ProjectRoadmap.Shared.IOptions.SharedKernel;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptionsWithFluentValidation<TOptions>(
        this IServiceCollection services,
        string configurationSection)
        where TOptions : class
    {
        services
            .AddOptions<TOptions>()
            .BindConfiguration(configurationSection)
            .ValidateFluentValidation()
            .ValidateOnStart();

        return services;
    }
}