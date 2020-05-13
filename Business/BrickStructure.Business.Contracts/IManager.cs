using AutoMapper;
using BrickStructure.Data.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BrickStructure.Business.Contracts
{
    public interface IManager<TEntity, TModel, TDataSource> 
        where TEntity : class, new()
        where TModel : TEntity, new()
        where TDataSource : IAgent<TEntity>
    {
        #region Properties
        TDataSource Agent { get; }
        ILogger Log { get; }
        IMapper Map { get; }
        //ClaimsPrincipal User { get; }
        #endregion

        #region Methods
        IQueryable<TModel> GetAll(bool track = true);
        Task InsertAsync(TModel item, CancellationToken cancellationToken = default);
        Task InsertRangeAsync(IEnumerable<TModel> items, CancellationToken cancellationToken = default);
        void Update(TModel item);
        void UpdateRange(IEnumerable<TModel> items);
        void Delete(TModel item);
        void DeleteRange(IEnumerable<TModel> items);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        IQueryable<TModel> QueryTable(string nativeSqlQuery);
        #endregion
    }
}
