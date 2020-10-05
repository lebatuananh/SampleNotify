using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;
using Shared.EF.Interfaces;

namespace Shared.Infrastructure
{
    public class Repository<TDbContext, T> : IRepository<T> where T : class where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public Repository(TDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
        }

        protected DbSet<T> DbSet => _dbContext.Set<T>();

        public async Task<QueryResult<T>> QueryAsync(Expression<Func<T, bool>> predicate, int skip, int take)
        {
            var queryable = _dbContext.Set<T>().Where(predicate);
            return await queryable.ToQueryResultAsync(skip, take);
        }

        public async Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(Guid entityId)
        {
            return await _dbContext.Set<T>().FindAsync(entityId);
        }

        public async Task<T> GetByIdAsync<TKey>(TKey entityId)
        {
            return await _dbContext.Set<T>().FindAsync(entityId);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate);
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete<TKey>(TKey entityId)
        {
            var entity = _dbContext.Find<T>(entityId);
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void DeleteMany(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task<int> CountAllAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().CountAsync(predicate);
        }

        public async Task<IList<TType>> GetAsync<TType>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TType>> select) where TType : class
        {
            return await _dbContext.Set<T>().Where(predicate).Select(select).ToListAsync();
        }

        public async Task<IList<TType>> GetAsync<TType>(Expression<Func<T, TType>> select) where TType : class
        {
            return await _dbContext.Set<T>().Select(select).ToListAsync();
        }

        public async Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> predicate, int skip, int take)
        {
            return await _dbContext.Set<T>().Where(predicate)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<T> GetSingleAsync()
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync();
        }
    }
}