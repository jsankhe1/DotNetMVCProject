using Core.Contracts.IRepositories;
using Core.Entities;
using Core.Helpers;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    private readonly MovieDbContext _movieDbContext;

    public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }

    public PagedResultSet<Movie> GetMoviesPaged(int pageNumber, int pageSize)
    {
        var totalMovies = _movieDbContext.Movies.Count();
        var movies = _movieDbContext.Movies
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedResultSet<Movie>
        {
            PageSize = pageSize,
            TotalCount = totalMovies,
            CurrentPage = pageNumber, // Now correctly stores the requested page number
            Items = movies
        };
    }

    public PagedResultSet<Movie> GetMoviesPagedByGenre(int? genreId, int pageNumber, int pageSize)
    {
        var genreQuery = _movieDbContext.Movies.AsQueryable();

        if (genreId.HasValue)
        {
            genreQuery = genreQuery
                .Where(m => m.MovieGenres.Any(g => g.GenreId == genreId.Value));
        }
        
        //total movies in that genre
        var totalMovies = genreQuery.Count();
        var genreMovies = genreQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();


        return new PagedResultSet<Movie>
        {
            PageSize = pageSize,
            TotalCount = totalMovies,
            CurrentPage = pageNumber,
            Items = genreMovies
        };
    }
}