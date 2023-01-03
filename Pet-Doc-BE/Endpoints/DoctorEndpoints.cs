using Pet_Doc_BE_Application.Contracts;

namespace Pet_Doc_BE.Endpoints;

public static class DoctorEndpoints
{
    public static void MapDoctorEndpoints(this WebApplication app)
    {
        app.MapGet("/docs", async (string city, string speciality, IDoctorFeature doctorFeature)
            => await doctorFeature
                .FindDoctors(city, speciality)
                .SafeExecute(() => Results.NotFound()));

        app.MapGet("/doc/{name}", async (string name, IDoctorFeature doctorFeature)
            => await doctorFeature
                .GetDoctorDetails(name)
                .SafeExecute(() => Results.NotFound()));

        app.MapGet("doc/{name}/schadule", async (string name, IDoctorFeature doctorFeature)
            => await doctorFeature
                .GetDoctorAppointments(name)
                .SafeExecute(() => Results.NotFound()));
    }
}
