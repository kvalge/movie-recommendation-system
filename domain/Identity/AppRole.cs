using Microsoft.AspNetCore.Identity;

namespace Domain.Identity;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole>? UserRoles { get; set; }
}