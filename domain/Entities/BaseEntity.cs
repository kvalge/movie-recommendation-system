using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }

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