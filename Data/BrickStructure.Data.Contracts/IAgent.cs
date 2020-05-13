using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BrickStructure.Data.Contracts
{
    /// <summary>
    /// Definición de lo que debe contener un agente de datos
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAgent<TEntity> where TEntity : class
    {
        #region Properties
        /// <summary>
        /// Acceso al log (debe suministrarse en el constructor)
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// Contexto que se va a usar en este agente (debe suministrarse en el constructor)
        /// </summary>
        IRepositoryContext DataContext { get; }
        #endregion

        #region Basic
        /// <summary>
        /// Gets the IQueryable value for query the model type.
        /// </summary>
        /// <param name="track">Tracking entity (true by default)</param>
        IQueryable<TEntity> GetAll(bool track = true);

        /// <summary>
        /// Adds to the repository the new model item
        /// </summary>
        /// <param name="item">Item to be added to the repository</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity item, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds to the repository the new collection model items
        /// </summary>
        /// <param name="items">Items to be added to the repository</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        Task InsertRangeAsync(IEnumerable<TEntity> items, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a model item from the repository (mark as modified)
        /// </summary>
        /// <param name="item">Item to be deleted from the repository</param>
        void Update(TEntity item);

        /// <summary>
        /// Update a collection model items from the repository (mark as modified)
        /// </summary>
        /// <param name="items">Items to be deleted from the repository</param>
        void UpdateRange(IEnumerable<TEntity> items);

        /// <summary>
        /// Delete a model item from the repository
        /// </summary>
        /// <param name="item">Item to be deleted from the repository</param>
        void Delete(TEntity item);

        /// <summary>
        /// Delete a collection model items from the repository
        /// </summary>
        /// <param name="items">Items to be deleted from the repository</param>
        void DeleteRange(IEnumerable<TEntity> items);

        /// <summary>
        /// Save changes to database in async mode
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion

        #region Advanced
        /// <summary>
        /// Gets the IQueryable value from a native sql query the model type.
        /// </summary>
        /// <param name="nativeSqlQuery">string as valid sql syntax</param>
        IQueryable<TEntity> QueryTable(string nativeSqlQuery);
        #endregion
    }
}
