namespace Pet_Doc_BE_Domain;

using Microsoft.Extensions.DependencyInjection;
using Pet_Doc_BE_Domain.Services;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services) 
        => services
        .AddInitialData()
        .AddScheduleGenerator();

    private static IServiceCollection AddInitialData(this IServiceCollection services)
        => services.AddTransient<IInitialData<Doctor[]>, DocSeedData>();

    private static IServiceCollection AddScheduleGenerator(this IServiceCollection services)
     => services
        .AddSingleton<ScheduleService>()
        .AddSingleton<MontlyCalendar>(x =>
            (date, doc) => ScheduleGenerator.Generate(x.GetRequiredService<ScheduleService>(), date, doc));

}
