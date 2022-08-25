namespace Pet_Doc_BE_Infrastructure.Persistence.Db_Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(MaxNameLength);

        builder.HasOne(d => d.Specialty)
               .WithMany()
               .HasForeignKey("SpecialtyId")
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Appointments)
               .WithOne();

        builder.HasMany(d => d.Certification)
               .WithOne();

        builder.HasMany(d => d.Schedule)
               .WithOne();

        builder.OwnsOne(d => d.Address, o => 
        {
            o.WithOwner();
            o.Property(o => o.City);
            o.Property(o => o.Street);
            o.Property(o => o.PhoneNumber);
            o.OwnsOne(a => a.mapPin, mp =>
            {
                mp.WithOwner();
                mp.Property(mp => mp.Latitude);
                mp.Property(mp => mp.Longitude);
            });
        });

    }
}
