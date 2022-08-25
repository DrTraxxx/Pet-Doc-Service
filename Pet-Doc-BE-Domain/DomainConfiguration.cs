namespace Pet_Doc_BE_Domain;

using Microsoft.Extensions.DependencyInjection;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services) 
        => services.AddInitialData();

    private static IServiceCollection AddInitialData(this IServiceCollection services)
        => services.AddTransient<IInitialData<Doctor[]>, DocSeedData>();
}
