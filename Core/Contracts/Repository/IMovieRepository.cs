using Core.Entities;
using Core.Helpers;

namespace Core.Contracts.IRepositories;

public interface IMovieRepository : IRepository<Movie>
{
    PagedResultSet<Movie> GetMoviesPaged(int pageNumber, int pageSize);

}