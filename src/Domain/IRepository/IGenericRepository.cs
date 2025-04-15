namespace Domain.IRepository;
public interface IGenericRepository<T> where T : class
{
    T GetById(int id);
    List<T> GetAll();
    void Delete(T entity);
    bool Update(T entity);
    bool Add(T entity);
    void SaveChanges();
}
