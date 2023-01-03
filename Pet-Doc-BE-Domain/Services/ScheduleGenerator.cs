namespace Pet_Doc_BE_Domain.Services;

using Pet_Doc_BE_Domain.Models.Doctor;


//Partial Application implementation to expose Generate method but keep the calculation logic in the domain 

public delegate (WorkDay, IEnumerable<WorkDay>) MontlyCalendar(DateTime fromDate, Doctor doc);

public static class ScheduleGenerator
{
   public static (WorkDay, IEnumerable<WorkDay>) Generate(ScheduleService service, DateTime fromDate, Doctor doc)
        => service.CalculateCalendar(fromDate, doc);
}
