using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> filter, 
            string? includeProperties = null, 
            bool tracked = false
            )
        {
            IQueryable<TEntity> query;
            if (tracked)
            {
                query = _dbSet;

            }
            else
            {
                query = _dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string? includeProperties = null,
            bool disableTracking = true
        )
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (
                    var includeProperty in includeProperties.Split(
                        new char[] { ',' },
                        StringSplitOptions.RemoveEmptyEntries
                    )
                )
                {
                    query = query.Include(includeProperty);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await orderBy(query).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.CountAsync(filter);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<TEntity> query;
            if (tracked)
            {
                query = _dbSet;

            }
            else
            {
                query = _dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, 
            string? includeProperties = null
            )
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
