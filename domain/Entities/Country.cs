using System.ComponentModel.DataAnnotations;

namespace domain.Entities;

public class Country : BaseEntity
{
    [MaxLength(128)] public string Name { get; set; } = null!;

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public ICollection<CastAndCrew> CastAndCrews { get; set; } = new List<CastAndCrew>();
}