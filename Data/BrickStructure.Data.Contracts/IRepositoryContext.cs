using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace BrickStructure.Data.Contracts
{
    public interface IRepositoryContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DatabaseFacade Database { get; }

        ChangeTracker ChangeTracker { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken ct = default);

        void Dispose();

        ValueTask DisposeAsync();
    }
}
