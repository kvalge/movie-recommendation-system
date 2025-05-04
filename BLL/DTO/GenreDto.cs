using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Domain.Identifiers;

namespace BLL.DTO;

public class GenreDto: IDomainId
{
    public int Id { get; set; }
    
    [MaxLength(128)] public string Name { get; set; } = null!;

    [MaxLength(2048)] public string? Description { get; set; }

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    
    [MaxLength(1024)] public string? Comments { get; set; }
}