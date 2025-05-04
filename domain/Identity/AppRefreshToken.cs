using Domain.Identifiers;

namespace Domain.Identity;

public class AppRefreshToken : BaseRefreshToken, IDomainUserId
{
    public int UserId { get; set; }
    public AppUser? User { get; set; }
}
