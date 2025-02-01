namespace Core.Contracts.IRepositories;

public interface IRepository<T> where T: class
{
    int Insert(T entity);
    int Update(T entity);
    int Delete(int id);

    IEnumerable<T> GetAll();

    IEnumerable<T> Search(Func<T, bool> predicate);

    T GetById(int id);
}