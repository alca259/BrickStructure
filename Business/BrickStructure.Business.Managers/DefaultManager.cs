using BrickStructure.Business.Contracts;
using BrickStructure.Data.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace BrickStructure.Business.Managers
{
    public class DefaultManager<TEntity, TModel, TDataSource> : IManager<TEntity, TModel, TDataSource>
        where TEntity : class, new()
        where TModel : TEntity, new()
        where TDataSource : IAgent<TEntity>
    {
        public TDataSource Agent { get; }
        public ILogger Log { get; }
        public ClaimsPrincipal User { get; }

        public DefaultManager(TDataSource source, ILogger log, ClaimsPrincipal user)
        {
            Agent = source;
            Log = log;
            User = user;
        }

        public IQueryable<TModel> GetAll()
        {
            return Agent.GetAll().Cast<TModel>().AsQueryable();
        }

        public Task InsertAsync(TModel item, CancellationToken cancellationToken = default)
        {
            return Agent.InsertAsync(item, cancellationToken).AsTask();
        }

        public Task InsertRangeAsync(IEnumerable<TModel> items, CancellationToken cancellationToken = default)
        {
            return Agent.InsertRangeAsync(items.Cast<TEntity>(), cancellationToken);
        }

        public void Update(TModel item)
        {
            Agent.Update(item);
        }

        public void UpdateRange(IEnumerable<TModel> items)
        {
            Agent.UpdateRange(items.Cast<TEntity>());
        }

        public void Delete(TModel item)
        {
            Agent.Delete(item);
        }

        public void DeleteRange(IEnumerable<TModel> items)
        {
            Agent.DeleteRange(items.Cast<TEntity>());
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Agent.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<TModel> QueryTable(string nativeSqlQuery)
        {
            return Agent.QueryTable(nativeSqlQuery).Cast<TModel>().AsQueryable();
        }
    }
}
