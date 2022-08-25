namespace Pet_Doc_BE_Application.Contracts;


public interface IDocsRepository : IRepository<Doctor>
{
    public Task<Doctor> Find(int id ,CancellationToken cancellationToken = default);
    public Task<Doctor> Update(int id, CancellationToken cancellationToken = default);
    public Task<IReadOnlyCollection<Doctor>> GetDoctorsList(int id, CancellationToken cancellationToken = default);   
        
}
