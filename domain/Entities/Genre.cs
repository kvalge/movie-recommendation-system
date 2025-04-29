using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Genre : BaseEntity
{
    [MaxLength(128)] public string Name { get; set; } = null!;

    [MaxLength(2048)] public string? Description { get; set; }

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}