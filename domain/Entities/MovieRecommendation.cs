using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Abstracts;
using Domain.Identity;

namespace Domain.Entities;

public class MovieRecommendation : BaseEntityUser<AppUser>
{
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }

    [Column(TypeName = "decimal(4,3)")] public decimal? Score { get; set; }

    [MaxLength(512)] public string? Reason { get; set; }

    public bool IsViewed { get; set; } = false;
}