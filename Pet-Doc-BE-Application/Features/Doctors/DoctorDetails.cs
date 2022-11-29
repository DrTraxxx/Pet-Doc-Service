namespace Pet_Doc_BE_Application.Features.Doctors;

public record DoctorDetails(string Name,string Speciality,string PhoneNumber,string Address, CertificationsOutput[] Certifications, Coordinates mapPin);
public record CertificationsOutput(string Title,DateTime IssueDate);
