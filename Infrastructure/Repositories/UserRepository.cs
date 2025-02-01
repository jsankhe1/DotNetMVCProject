using Core.Contracts.IRepositories;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly MovieDbContext _movieDbContext;

    public UserRepository (MovieDbContext movieDbContext) : base(movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
}