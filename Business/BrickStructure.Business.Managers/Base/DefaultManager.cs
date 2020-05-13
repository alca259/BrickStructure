using AutoMapper;
using AutoMapper.QueryableExtensions;
using BrickStructure.Business.Contracts;
using BrickStructure.Data.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BrickStructure.Business.Managers
{
    public class DefaultManager<TEntity, TModel, TDataSource> : IManager<TEntity, TModel, TDataSource>
        where TEntity : class, new()
        where TModel : class, TEntity, new()
        where TDataSource : IAgent<TEntity>
    {
        public TDataSource Agent { get; }
        public ILogger Log { get; }
        public IMapper Map { get; }
        //public ClaimsPrincipal User { get; }

        public DefaultManager(TDataSource source, ILogger<DefaultManager<TEntity, TModel, TDataSource>> log, IMapper mapper = null)//, ClaimsPrincipal user)
        {
            Agent = source;
            Log = log;
            Map = mapper;
            //User = user;
        }

        public virtual IQueryable<TModel> GetAll(bool track = true)
        {
            return Agent.GetAll(track).ProjectTo<TModel>(Map.ConfigurationProvider);
        }

        public virtual Task InsertAsync(TModel item, CancellationToken cancellationToken = default)
        {
            return Agent.InsertAsync(item, cancellationToken).AsTask();
        }

        public virtual Task InsertRangeAsync(IEnumerable<TModel> items, CancellationToken cancellationToken = default)
        {
            return Agent.InsertRangeAsync(items.Cast<TEntity>(), cancellationToken);
        }

        public virtual void Update(TModel item)
        {
            Agent.Update(item);
        }

        public virtual void UpdateRange(IEnumerable<TModel> items)
        {
            Agent.UpdateRange(items.Cast<TEntity>());
        }

        public virtual void Delete(TModel item)
        {
            Agent.Delete(item);
        }

        public virtual void DeleteRange(IEnumerable<TModel> items)
        {
            Agent.DeleteRange(items.Cast<TEntity>());
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Agent.SaveChangesAsync(cancellationToken);
        }

        public virtual IQueryable<TModel> QueryTable(string nativeSqlQuery)
        {
            return Agent.QueryTable(nativeSqlQuery).ProjectTo<TModel>(Map.ConfigurationProvider);
        }
    }
}
