namespace Pet_Doc_BE_Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Pet_Doc_BE_Domain.Specifications;

internal class DocsRepository : IRepository<Doctor>
{
    private PetDocDbContext _context;

    public DocsRepository(PetDocDbContext context) => _context = context;
   
    public async Task<Doctor> Find(Specification<Doctor> specification, CancellationToken cancellationToken = default)
     => await _context.Doctors
            .Include(d => d.Specialty).AsSplitQuery()
            .Include(d => d.Appointments).AsSplitQuery()
            .Include(d => d.Certification).AsSingleQuery()
            .SingleOrDefaultAsync(specification, cancellationToken: cancellationToken);

    public async Task<IReadOnlyCollection<Doctor>> Get(Specification<Doctor> specification = null!, CancellationToken cancellationToken = default)
     => specification is null
        ? await _context.Doctors.Include(d => d.Specialty).AsSplitQuery().ToArrayAsync()
        : await _context.Doctors.Include(d => d.Specialty).AsSplitQuery()
            .Where(specification)
            .ToArrayAsync();

    public async Task Save(Doctor entity, CancellationToken cancellationToken = default)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public Task<Doctor> Update(Specification<Doctor> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
