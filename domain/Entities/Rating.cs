using Domain.Entities.Abstracts;
using Domain.Identity;

namespace Domain.Entities;

public class Rating : BaseEntityUser<AppUser>
{
    public int RatingValueId { get; set; }
    public RatingValue RatingValue { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    
    public int UserId { get; set; }
    public AppUser User { get; set; } = null!;
}