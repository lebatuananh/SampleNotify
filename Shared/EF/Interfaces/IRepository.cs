using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shared.Dto;

namespace Shared.EF.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<QueryResult<T>> QueryAsync(Expression<Func<T, bool>> predicate, int skip, int take);
        Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetAllAsync();
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(Guid entityId);
        Task<T> GetByIdAsync<TKey>(TKey entityId);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete<TKey>(TKey entityId);
        void Delete(T entity);
        void DeleteMany(IEnumerable<T> entities);
        Task<int> CountAllAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}