using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZStore.Infrastructure.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetOneAsync(
            Expression<Func<TEntity, bool>> filter, 
            string? includeProperties = null, 
            bool tracked = false
            );
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string? includeProperties = null,
            bool disableTracking = true
        );

        Task<TEntity?> GetByIdAsync(object id);

        Task InsertAsync(TEntity entity);

        Task InsertRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Add(TEntity entity);
        TEntity? Get(Expression<Func<TEntity, bool>> filter, string? includeProperties = null, bool tracked = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, string? includeProperties = null);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
    }
}
