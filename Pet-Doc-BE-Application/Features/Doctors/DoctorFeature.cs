namespace Pet_Doc_BE_Application.Features.Doctors;

internal class DoctorFeature : IDoctorFeature
{
    private IRepository<Doctor> _repository;

    public DoctorFeature(IRepository<Doctor> repository) => _repository = repository;

    public async Task<IReadOnlyCollection<DoctorOutputModel>> FindDoctors(string city, string speciality)
          => (await _repository
             .Get(new DoctorByCity(city)
             .And(new DoctorBySpeciality(speciality))))
             .Select(d => new DoctorOutputModel(d.Name, d.Specialty.Name, d.Address.City))
             .ToArray();
}
