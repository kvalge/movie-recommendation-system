using System.ComponentModel.DataAnnotations;
using domain.Identity;

namespace domain.Entities;

public class Review : BaseEntity
{
    [MaxLength(8192)] public string Text { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    
    public int UserId { get; set; }
    public AppUser User { get; set; } = null!;
}