namespace Pet_Doc_BE_Application.Features.Doctors;

using AutoMapper;
using Pet_Doc_BE_Application.Extensions;
using Pet_Doc_BE_Domain.Models.Doctor;
using Pet_Doc_BE_Domain.Services;

internal class DoctorFeature : IDoctorFeature
{
    private IRepository<Doctor> _repository;
    private IMapper _mapper;
    private MontlyCalendar _getCalendar;

    public DoctorFeature(
        IRepository<Doctor> repository ,
        IMapper mapper,
        MontlyCalendar getCalendar)
    {
        _repository = repository;
        _mapper = mapper;
        _getCalendar = getCalendar;
    }

    public async Task<IReadOnlyCollection<DoctorOutputModel>> FindDoctors(string city, string speciality)
          => (await _repository
             .Get(new DoctorByCity(city).And(new DoctorBySpeciality(speciality))))
             .Select(d => new DoctorOutputModel(d.Name, d.Specialty.Name, d.Address.City))
             .ToArray();

    public async Task<DoctorDetails> GetDoctorDetails(string name) 
        => (await _repository
        .Find(new DoctorByName(name)))
        .MapTo<DoctorDetails,Doctor>(_mapper);

    public async Task<DoctorAppointments> GetDoctorAppointments(string name)
    {
        var doc = await _repository.Find(new DoctorByName(name));
        var date = DateTime.Now;

        (var today,var montlyCalendar ) = _getCalendar(date, doc);

        return new(today,montlyCalendar);
    }
        
}