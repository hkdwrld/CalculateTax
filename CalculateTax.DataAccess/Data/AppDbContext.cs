using CalculateTax.Models.AuthUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CalculateTax.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<AuthUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //public DbSet<TaxForm> TaxForms { get; set; }
    }
}
