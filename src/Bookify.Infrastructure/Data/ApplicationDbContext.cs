using Bookify.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
        
    }
}
