using System.Linq.Expressions;

namespace LMS.Core.Infrastructure.Database.Abstractions
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetList(Expression<Func<T, bool>>? predicate=null);
        T? Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
