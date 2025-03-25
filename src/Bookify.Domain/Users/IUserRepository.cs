namespace Bookify.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetById(Guid id, CancellationToken cancellationToken = default);

    Task Add(User user, CancellationToken cancellationToken = default);
}