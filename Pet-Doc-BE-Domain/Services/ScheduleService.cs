namespace Pet_Doc_BE_Domain.Services;

using Models.Doctor;

public sealed class ScheduleService
{
    public (WorkDay, IEnumerable<WorkDay>) CalculateCalendar(DateTime fromDate, Doctor doc)
    {
        var schedule = GetMontlySchedule(fromDate, doc);

        return (schedule.First(), schedule);
    }

    private IEnumerable<WorkDay> GetMontlySchedule(DateTime fromDate,Doctor doc)
    {
        foreach (int indx in Enumerable.Range(0, 30))
        {
            var date = fromDate.AddDays(indx);
            var slots = doc.GetAppointmentHours();

            if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) continue;

            var slotsCollection = date.Date != DateTime.Today
                ? slots
                : GetTodaySlots(slots,TimeOnly.FromDateTime(date),doc);

            var daylislots = !slotsCollection.Any() 
                ? slotsCollection 
                : slotsCollection
                    .Except(doc.Appointments
                      .Where(x => x.AppointmentDate.Date.Equals(date.Date))
                      .Select(x => x.Slot));

            yield return new(date.DayOfWeek.ToString(), date.Date.ToString(), daylislots);
        }
    } 

    private IEnumerable<string> GetTodaySlots(IEnumerable<string> slots, TimeOnly currentTime , Doctor doc)
    {
        var lastSlot = TimeOnly.Parse(doc.Schedule.LastSlot);
        var firstSlot = TimeOnly.Parse(doc.Schedule.FirstSlot);
       
        return currentTime > lastSlot ? Enumerable.Empty<string>() 
            : currentTime < firstSlot ? slots 
            : slots.Skip(lastSlot.Hour - currentTime.Hour) ;
    }
}
  