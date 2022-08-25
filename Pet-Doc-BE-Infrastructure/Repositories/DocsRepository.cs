namespace Pet_Doc_BE_Infrastructure.Repositories;

internal class DocsRepository : IDocsRepository
{
    private PetDocDbContext _context;

    public DocsRepository(PetDocDbContext context)
    {
        _context = context;
    }

    public Task<Doctor> Find(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    //public async Task<IEnumerable<Doctor>> GetDocs()
    //{
    //    var result = _context.Doctors
    //        .Include(d => d.Appointments)
    //        .AsSplitQuery()
    //        .Include(d => d.Specialty)
    //        .AsSplitQuery()
    //        .Include(d => d.Certification);

    //    return await Task.FromResult(result);
    //}

    public Task<IReadOnlyCollection<Doctor>> GetDoctorsList(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Save(Doctor entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> Update(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
