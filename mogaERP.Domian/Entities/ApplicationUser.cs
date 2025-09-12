using Microsoft.AspNetCore.Identity;

namespace mogaERP.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public bool IsActive { get; set; } = true;
}
