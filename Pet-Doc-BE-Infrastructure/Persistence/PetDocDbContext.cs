namespace Pet_Doc_BE_Infrastructure.Persistence;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Doc_BE_Infrastructure.Identity;
using System.Reflection;

internal class PetDocDbContext : IdentityDbContext<User>
{
	public PetDocDbContext(DbContextOptions<PetDocDbContext> options) 
		: base(options)
	{
	}

    public DbSet<Doctor> Doctors { get; set; } = default!;
	public DbSet<Appointment> Appointments { get; set; } = default!;
	public DbSet<Speciality> Speciality { get; set; } = default!;


	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		base.OnModelCreating(builder);
	}
}

