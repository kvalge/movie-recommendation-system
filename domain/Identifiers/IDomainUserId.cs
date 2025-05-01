namespace Domain.Identifiers;

public interface IDomainUserId: IDomainUserId<int>
{
}

public interface IDomainUserId<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey UserId { get; set; }
}
