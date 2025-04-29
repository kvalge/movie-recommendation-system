using Microsoft.AspNetCore.Identity;

namespace domain.Identity;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole>? UserRoles { get; set; }
}