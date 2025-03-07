namespace Bookify.Application.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> Commit(CancellationToken cancellationToken);
}
