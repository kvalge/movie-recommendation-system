using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Domain.Identifiers;
using Domain.Identity;

namespace BLL.DTO;

public class RatingDto : IDomainId
{
    public int Id { get; set; }
    
    public int RatingValueId { get; set; }
    public RatingValue RatingValue { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    
    [MaxLength(1024)] public string? Comments { get; set; }
}