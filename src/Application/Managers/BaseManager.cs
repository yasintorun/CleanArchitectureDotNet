using LMS.Application.Abstractions.Services;
using LMS.Core.Domain.Abstractions;

namespace LMS.Application.Managers
{
    public abstract class BaseManager<T> : IBaseService<T> where T: IEntity
    {

    }
}
