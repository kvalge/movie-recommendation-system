using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Identifiers;

namespace BLL.DTO;

public class MovieRecommendationDto : IDomainId
{
    public int Id { get; set; }
    
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }

    [Column(TypeName = "decimal(4,3)")] public decimal? Score { get; set; }

    [MaxLength(512)] public string? Reason { get; set; }

    public bool IsViewed { get; set; } = false;
    
    [MaxLength(1024)] public string? Comments { get; set; }
}