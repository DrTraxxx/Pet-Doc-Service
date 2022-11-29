namespace Pet_Doc_BE_Application.Profiles;

using AutoMapper;
using Pet_Doc_BE_Application.Features.Doctors;

public class DoctorDetailsProfile : Profile
{
	public DoctorDetailsProfile()
	{
		CreateMap<Doctor, DoctorDetails>()
			.ForCtorParam(ctorParamName:"Name", opt => opt.MapFrom(doc => doc.Name))
			.ForCtorParam(ctorParamName:"Address", opt => opt.MapFrom(doc => doc.Address.Street))
            .ForCtorParam(ctorParamName: "Speciality", opt => opt.MapFrom(doc => doc.Specialty.Name))
            .ForCtorParam(ctorParamName: "PhoneNumber", opt => opt.MapFrom(doc => doc.Address.PhoneNumber))
            .ForCtorParam(ctorParamName:"mapPin", opt => opt.MapFrom(doc => doc.Address.mapPin))
			.ForCtorParam(ctorParamName: "Certifications", opt => opt.MapFrom(doc => doc.Certification.ToArray()));

		CreateMap<Certification, CertificationsOutput>()
			.ForCtorParam(ctorParamName: "Title", opt => opt.MapFrom(c => c.Name))
			.ForCtorParam(ctorParamName: "IssueDate", opt => opt.MapFrom(c => c.IssueDate));
	}
}
