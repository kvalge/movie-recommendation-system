using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Domain.Identifiers;
using Domain.Identity;

namespace BLL.DTO;

public class ReviewDto: IDomainId
{
    public int Id { get; set; }
    
    [MaxLength(8192)] public string Text { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    
    public int UserId { get; set; }
    public AppUser User { get; set; } = null!;
}