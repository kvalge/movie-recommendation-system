using System.Security.Claims;

namespace Helpers;

public static class IdentityExtensions
{
    public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var userIdStr = claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var userId = int.Parse(userIdStr);
        return userId;
    }
}