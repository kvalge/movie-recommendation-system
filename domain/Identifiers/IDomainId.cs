namespace Domain.Identifiers;

public interface IDomainId : IDomainId<int>
{
}

public interface IDomainId<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}