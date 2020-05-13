using BrickStructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BrickStructure.Data.Agents
{
    public class DefaultAgent<TEntity> : IAgent<TEntity> where TEntity : class
    {
        #region Properties
        /// <summary>
        /// Acceso al log (debe suministrarse en el constructor)
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>
        /// Contexto que se va a usar en este agente (debe suministrarse en el constructor)
        /// </summary>
        public IRepositoryContext DataContext { get; }
        #endregion

        #region Constructor
        public DefaultAgent(
            ILogger logger,
            IRepositoryContext context)
        {
            Logger = logger;
            DataContext = context;
        }
        #endregion

        #region Basic
        /// <summary>
        /// Gets the IQueryable value for query the model type.
        /// </summary>
        public virtual IQueryable<TEntity> GetAll(bool track = true)
        {
            return track
                ? DataContext.Set<TEntity>().AsQueryable()
                : DataContext.Set<TEntity>().AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Adds to the repository the new model item
        /// </summary>
        /// <param name="item">Item to be added to the repository</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        public virtual ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            return DataContext.Set<TEntity>().AddAsync(item, cancellationToken);
        }

        /// <summary>
        /// Adds to the repository the new collection model items
        /// </summary>
        /// <param name="items">Items to be added to the repository</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        public virtual Task InsertRangeAsync(IEnumerable<TEntity> items, CancellationToken cancellationToken = default)
        {
            return DataContext.Set<TEntity>().AddRangeAsync(items, cancellationToken);
        }

        /// <summary>
        /// Update a model item from the repository (mark as modified)
        /// </summary>
        /// <param name="item">Item to be deleted from the repository</param>
        public virtual void Update(TEntity item)
        {
            var state = DataContext.Entry(item).State;

            if (state == EntityState.Detached)
            {
                Logger.LogWarning("Entity is not tracked. Cannot be updated.");
                return;
            }

            DataContext.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Update a collection model items from the repository (mark as modified)
        /// </summary>
        /// <param name="items">Items to be deleted from the repository</param>
        public virtual void UpdateRange(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                var state = DataContext.Entry(item).State;

                if (state == EntityState.Detached)
                {
                    continue;
                }

                DataContext.Entry(item).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Delete a model item from the repository
        /// </summary>
        /// <param name="item">Item to be deleted from the repository</param>
        public virtual void Delete(TEntity item)
        {
            var state = DataContext.Entry(item).State;

            if (state != EntityState.Detached)
            {
                DataContext.Set<TEntity>().Remove(item);
                return;
            }

            Logger.LogWarning("Entity is not tracked. Cannot be deleted.");
        }

        /// <summary>
        /// Delete a collection model items from the repository
        /// </summary>
        /// <param name="items">Items to be deleted from the repository</param>
        public virtual void DeleteRange(IEnumerable<TEntity> items)
        {
            var deletableEntities = new List<TEntity>();

            foreach (var item in items)
            {
                var state = DataContext.Entry(item).State;

                if (state != EntityState.Detached)
                {
                    deletableEntities.Add(item);
                }
            }

            DataContext.Set<TEntity>().RemoveRange(deletableEntities);
        }

        /// <summary>
        /// Save changes to database in async mode
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return DataContext.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region Advanced
        /// <summary>
        /// Gets the IQueryable value from a native sql query the model type.
        /// </summary>
        /// <param name="nativeSqlQuery">string as valid sql syntax</param>
        public virtual IQueryable<TEntity> QueryTable(string nativeSqlQuery)
        {
            return DataContext.Set<TEntity>().FromSqlRaw<TEntity>(nativeSqlQuery).AsQueryable();
        }
        #endregion
    }
}
