namespace Pet_Doc_BE_Application.Contracts;

using Pet_Doc_BE_Application.Features.Doctors;

public interface IDoctorFeature
{
    Task<IReadOnlyCollection<DoctorOutputModel>> FindDoctors(string city, string speciality);
}
