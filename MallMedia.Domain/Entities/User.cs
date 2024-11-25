using Microsoft.AspNetCore.Identity;

namespace MallMedia.Domain.Entities;

public class User : IdentityUser
{
    public override string? Email { get; set; } = null;
}
