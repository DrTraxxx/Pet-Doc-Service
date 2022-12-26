namespace Pet_Doc_BE_Application.Features.Doctors;

public record DoctorAppointments(WorkDay Today, IEnumerable<WorkDay> MontlySchadule);
