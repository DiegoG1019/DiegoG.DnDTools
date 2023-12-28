using System.Numerics;

namespace DiegoG.DnDTools.Services.Data;

public interface IKeyed<TEntity, TKey> : IEquatable<TEntity>
    where TKey : unmanaged, IEquatable<TKey>
    where TEntity : class, IKeyed<TEntity, TKey>
{
    public TKey Id { get; }

    bool IEquatable<TEntity>.Equals(TEntity? other)
        => other is TEntity o && o.Id.Equals(Id);
}
