using Bookify.Domain.Apartments;
using Bookify.Infrastructure.Data;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task Add(Apartment apartment, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
