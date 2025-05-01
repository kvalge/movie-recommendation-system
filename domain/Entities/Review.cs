using System.ComponentModel.DataAnnotations;
using Domain.Entities.Abstracts;
using Domain.Identity;

namespace Domain.Entities;

public class Review : BaseEntityUser<AppUser>
{
    [MaxLength(8192)] public string Text { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    
    public int UserId { get; set; }
    public AppUser User { get; set; } = null!;
}