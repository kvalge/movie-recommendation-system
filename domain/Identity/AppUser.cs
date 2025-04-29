using Domain.Entities;

namespace Domain.Identity;

using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser<int>
{
    public DateTime? DateOfBirth { get; set; }

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public ICollection<AppUserRole>? UserRoles { get; set; }
}