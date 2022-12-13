namespace Pet_Doc_BE_Domain.Services;

using Pet_Doc_BE_Domain.Models.Doctor.WorkCalendar;


//Partial Application implementation to expose CalculateCalendar method but keep the calculation logic in the domain 

public delegate Calendar MontlyCalendar(DateTime fromDate, Doctor doc);

public static class ScheduleGenerator
{
   public static Calendar Generate(ScheduleService service, DateTime fromDate, Doctor doc)
        => service.CalculateCalendar(fromDate, doc);
}
