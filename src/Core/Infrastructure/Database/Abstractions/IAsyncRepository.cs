using LMS.Core.Domain.Abstractions;
using LMS.Core.Domain.Models;
using System.Linq.Expressions;

namespace LMS.Core.Infrastructure.Database.Abstractions
{
    public interface IAsyncRepository<T>
    {
        Task<IList<T>> GetListAysnc(Expression<Func<T, bool>>? predicate=null);
        Task<Paginate<T>> GetListWithPaginateAsync(Expression<Func<T, bool>>? predicate, IPaginateRequest paginateRequest, Func<T, object>? orderby);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
