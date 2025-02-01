using Core.Contracts.IRepositories;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    private readonly MovieDbContext _movieDbContext;

    public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
}