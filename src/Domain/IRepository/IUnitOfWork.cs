namespace Domain.IRepository;

public interface IUnitOfWork : IDisposable
{
    IApplicantRepository ApplicantRepository { get; }
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync();
    Task<bool> SaveChangesReturnBoolAsync();
}
