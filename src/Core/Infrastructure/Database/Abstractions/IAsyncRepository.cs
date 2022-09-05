using System.Linq.Expressions;

namespace LMS.Core.Infrastructure.Database.Abstractions
{
    public interface IAsyncRepository<T>
    {
        Task<IEnumerable<T>> GetListAysnc(Expression<Func<T, bool>>? predicate);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
