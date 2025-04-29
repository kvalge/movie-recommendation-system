using Microsoft.AspNetCore.Identity;

namespace domain.Identity;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser? User { get; set; }
    
    public AppRole? Role { get; set; }
}