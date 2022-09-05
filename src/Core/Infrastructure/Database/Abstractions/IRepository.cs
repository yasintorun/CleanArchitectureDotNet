
namespace LMS.Core.Infrastructure.Database.Abstractions
{
    public interface IRepository<T> : IAsyncRepository<T>, IBaseRepository<T>
    {
    }
}
