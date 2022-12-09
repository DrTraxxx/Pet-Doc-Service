namespace Pet_Doc_BE_Application.Features.Doctors;

using AutoMapper;
using Pet_Doc_BE_Application.Extensions;

internal class DoctorFeature : IDoctorFeature
{
    private IRepository<Doctor> _repository;
    private IMapper _mapper;

    public DoctorFeature(IRepository<Doctor> repository ,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<DoctorOutputModel>> FindDoctors(string city, string speciality)
          => (await _repository
             .Get(new DoctorByCity(city)
             .And(new DoctorBySpeciality(speciality))))
             .Select(d => new DoctorOutputModel(d.Name, d.Specialty.Name, d.Address.City))
             .ToArray();

    public async Task<DoctorDetails> GetDoctorDetails(string name) 
        => (await _repository
        .Find(new DoctorByName(name)))
        .MapTo<DoctorDetails,Doctor>(_mapper);

    public async Task<DoctorAppointments> GetDoctorAppointments(string name)
    {
        var doc = await _repository.Find(new DoctorByName(name));

        var test1 = doc.GetDoctorCalendar(DateTime.Now);

        return new();
    }
        
}