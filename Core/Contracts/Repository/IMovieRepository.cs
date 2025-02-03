using Core.Entities;
using Core.Helpers;
using Core.Models;

namespace Core.Contracts.IRepositories;

public interface IMovieRepository : IRepository<Movie>
{
    PagedResultSet<Movie> GetMoviesPaged(int pageNumber, int pageSize);
    PagedResultSet<Movie> GetMoviesPagedByGenre(int? genreId, int pageNumber, int pageSize);

    IEnumerable<MovieCastModel> GetMoviesCast(int movieId);
    IEnumerable<MovieTrailerModel> GetMovieTrailers(int movieId);

}