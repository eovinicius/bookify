using Bookify.Domain.Users;
using Bookify.Infrastructure.Data;

namespace Bookify.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task Add(User user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}