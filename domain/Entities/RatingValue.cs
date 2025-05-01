using Domain.Entities.Abstracts;
using Domain.Identity;

namespace Domain.Entities;

public class RatingValue : BaseEntityUser<AppUser>
{
    public int Value { get; set; }
    
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}