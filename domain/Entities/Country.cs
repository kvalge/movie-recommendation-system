using System.ComponentModel.DataAnnotations;
using Domain.Entities.Abstracts;
using Domain.Identity;

namespace Domain.Entities;

public class Country : BaseEntityUser<AppUser>
{
    [MaxLength(128)] public string Name { get; set; } = null!;

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public ICollection<CastAndCrew> CastAndCrews { get; set; } = new List<CastAndCrew>();
}