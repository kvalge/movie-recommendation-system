using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Domain.Identifiers;

namespace BLL.DTO;

public class CountryDto: IDomainId
{
    public int Id { get; set; }
    
    [MaxLength(128)] public string Name { get; set; } = null!;

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public ICollection<CastAndCrew> CastAndCrews { get; set; } = new List<CastAndCrew>();
    
    [MaxLength(1024)] public string? Comments { get; set; }
}