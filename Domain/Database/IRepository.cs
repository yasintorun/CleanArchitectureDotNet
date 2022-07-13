using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Database
{
    //General CRUD operations
    public interface IRepository<T>
    {
        //Create
        T Add(T entity);
        Task<T> AddAsync(T entity);

        //Read - Get
        List<T> Get(Expression<Func<T, bool>>? predicate);
        Task<List<T>> GetAsync(Expression<Func<T, bool>>? predicate);

        //Update
        T Update(T entity);
        Task<T> UdateAsync(T entity);

        //Delete
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);

        bool IsExists(Expression<Func<T, bool>> predicate);
    }
}
