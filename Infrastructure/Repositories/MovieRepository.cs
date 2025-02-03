using Core.Contracts.IRepositories;
using Core.Entities;
using Core.Helpers;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        var movies = _movieDbContext.Movies.AsNoTracking()
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
        var genreQuery = _movieDbContext.Movies.AsNoTracking().AsQueryable();

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

    public IEnumerable<MovieCastModel> GetMoviesCast(int movieId)
    {
        var castWithCharacters = _movieDbContext.Movies.AsNoTracking()
            .Where(m => m.Id == movieId)
            .SelectMany(m => m.MovieCasts)
            .Select(mc => new MovieCastModel()
            {
                ActorName = mc.Cast.Name,
                CharacterName = mc.Character,
                ProfileImageUrl = mc.Cast.ProfilePath,
                TmdbProfile = mc.Cast.TmdbUrl

            }).ToList();
        
        return castWithCharacters;
    }

    public IEnumerable<MovieTrailerModel> GetMovieTrailers(int movieId)
    {
        var trailerModels = _movieDbContext.Movies.AsNoTracking()
            .Where(m => m.Id == movieId)
            .SelectMany(m => m.Trailers)
            .Select(mt => new MovieTrailerModel
            {
                TrailerName = mt.Name,
                TrailerUrl = mt.Name
            }).ToList();

        return trailerModels;

    }
    public new Movie GetById(int movieId)
    {
        return _movieDbContext.Movies
            .Include(m => m.Reviews)
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .FirstOrDefault(m => m.Id == movieId);
    }
}