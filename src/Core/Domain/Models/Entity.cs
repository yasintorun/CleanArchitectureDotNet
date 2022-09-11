using LMS.Core.Domain.Abstractions;

namespace LMS.Core.Domain.Models;
public abstract class Entity : IEntity
{
    public int Id { get; set ; }
}
