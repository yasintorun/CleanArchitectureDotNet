using Kod.Core.Domain.Abstractions;

namespace Kod.Core.Domain.Models;
public abstract class Entity : IEntity
{
    public int Id { get; set ; }
}
