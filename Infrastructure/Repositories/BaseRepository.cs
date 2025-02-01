using Core.Contracts.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T: class
{
    private readonly MovieDbContext _movieDbContext;

    public BaseRepository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
    public int Insert(T entity)
    {
        _movieDbContext.Set<T>().Add(entity);
        return _movieDbContext.SaveChanges();
    }

    public int Update(T entity)
    {
        _movieDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return _movieDbContext.SaveChanges();
    }

    public int Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _movieDbContext.Set<T>().Remove(entity);
        }

        return _movieDbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return _movieDbContext.Set<T>();
    }

    public IEnumerable<T> Search(Func<T, bool> predicate)
    {
       return _movieDbContext.Set<T>().Where(predicate);
    }

    public T GetById(int id)
    {
       return _movieDbContext.Set<T>().Find(id);
    }
}