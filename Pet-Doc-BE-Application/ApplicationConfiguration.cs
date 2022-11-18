namespace Pet_Doc_BE_Application;

using Microsoft.Extensions.DependencyInjection;
using Pet_Doc_BE_Application.Features.Doctors;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplicationComponents(this IServiceCollection services)
       => services.AddScoped<IDoctorFeature, DoctorFeature>();
}
