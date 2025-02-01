using Core.Contracts.IRepositories;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CastRepository : BaseRepository<Cast>, ICastRepository
{
    private readonly MovieDbContext _movieDbContext;

    public CastRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
}