using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GenericRepository<T>(AppDBContext dbContext) : IGenericRepository<T> where T : class
{
    internal readonly AppDBContext _dbContext = dbContext;
    public bool Add(T entity) 
    {
        try
        {
            _dbContext.Set<T>().Add(entity);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

    public List<T> GetAll() => [.. _dbContext.Set<T>()];

    public T GetById(int id) => _dbContext.Set<T>().Find(id);

    public void SaveChanges() => _dbContext.SaveChanges();

    public bool Update(T entity)
    {
        try
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }
}
