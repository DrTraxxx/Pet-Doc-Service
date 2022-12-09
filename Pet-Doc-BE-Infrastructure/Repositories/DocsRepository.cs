using Microsoft.EntityFrameworkCore;
using Pet_Doc_BE_Domain.Specifications;

namespace Pet_Doc_BE_Infrastructure.Repositories;

internal class DocsRepository : IRepository<Doctor>
{
    private PetDocDbContext _context;

    public DocsRepository(PetDocDbContext context) => _context = context;
   
    public async Task<Doctor> Find(Specification<Doctor> specification, CancellationToken cancellationToken = default)
     => await _context.Doctors
            .Include(d => d.Specialty).AsSplitQuery()
            .Include(d => d.Appointments)
            .Include(d => d.Certification).AsSingleQuery()
            .SingleOrDefaultAsync(specification, cancellationToken: cancellationToken);

    public async Task<IReadOnlyCollection<Doctor>> Get(Specification<Doctor> specification = null!, CancellationToken cancellationToken = default)
     => specification is null
        ? await _context.Doctors.Include(d => d.Specialty).AsSplitQuery().ToArrayAsync()
        : await _context.Doctors.Include(d => d.Specialty).AsSplitQuery()
            .Where(specification)
            .ToArrayAsync();

    public Task Save(Doctor entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> Update(Specification<Doctor> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
