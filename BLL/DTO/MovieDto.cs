using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Identifiers;
using Domain.Identity;

namespace BLL.DTO;

public class MovieDto : IDomainId
{
    public int Id { get; set; }

    [MaxLength(256)] public string Title { get; set; } = null!;

    private DateTime? _releaseYear;

    public DateTime? ReleaseYear
    {
        get => _releaseYear;
        set => _releaseYear = value?.ToUniversalTime();
    }
    
    public int? Duration { get; set; }

    [MaxLength(2048)] public string? Description { get; set; }

    [MaxLength(1024)] public string? ImageUrl { get; set; }

    [Column(TypeName = "decimal(4,1)")] public decimal? AvRating { get; set; }

    public int? RatingCount { get; set; }

    public ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public ICollection<CastAndCrew> CastAndCrews { get; set; } = new List<CastAndCrew>();

    public ICollection<Country> Countries { get; set; } = new List<Country>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public int UserId { get; set; }
    public AppUser User { get; set; } = null!;
}