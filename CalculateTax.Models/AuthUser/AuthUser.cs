using Microsoft.AspNetCore.Identity;

namespace CalculateTax.Models.AuthUser
{
    public class AuthUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
