using Core.Contracts.IRepositories;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    private readonly MovieDbContext _movieDbContext;

    public GenreRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
}