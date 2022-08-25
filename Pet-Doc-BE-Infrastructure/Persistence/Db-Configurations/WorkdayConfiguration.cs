namespace Pet_Doc_BE_Infrastructure.Persistence.Db_Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WorkdayConfiguration : IEntityTypeConfiguration<WorkingDay>
{
    public void Configure(EntityTypeBuilder<WorkingDay> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.DayOfWeek).IsRequired();
        builder.Property(t => t.FirstSlot).IsRequired();
        builder.Property(t => t.DailySlots).IsRequired();
    }
}
