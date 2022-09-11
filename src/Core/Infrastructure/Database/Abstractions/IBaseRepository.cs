using LMS.Core.Domain.Abstractions;
using LMS.Core.Domain.Models;
using System.Linq.Expressions;

namespace LMS.Core.Infrastructure.Database.Abstractions
{
    public interface IBaseRepository<T>
    {
        IList<T> GetList(Expression<Func<T, bool>>? predicate=null);
        Paginate<T> GetListWithPaginate(Expression<Func<T, bool>>? predicate, IPaginateRequest paginateRequest, Func<T, object> orderby);
        T? Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
