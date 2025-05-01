using System.ComponentModel.DataAnnotations;
using Domain.Identifiers;

namespace Domain.Entities;

public abstract class Entity : Entity<int>, IDomainId
{
}

public abstract class Entity<TKey> : IDomainId<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; } = default!;
 
    [MaxLength(128)] public string CreatedBy { get; set; } = null!;

    private DateTime? _createdAt;
    public DateTime? CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value?.ToUniversalTime();
    }

    [MaxLength(128)] public string ModifiedBy { get; set; } = null!;

    private DateTime? _modifiedAt;
    public DateTime? ModifiedAt
    {
        get => _modifiedAt;
        set => _modifiedAt = value?.ToUniversalTime();
    }

    [MaxLength(1024)] public string? Comments { get; set; }
}