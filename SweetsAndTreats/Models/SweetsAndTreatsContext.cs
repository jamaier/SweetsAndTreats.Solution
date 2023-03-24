using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SweetsAndTreats.Models
{
  public class SweetsAndTreatsContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<TreatFlavor> TreatFlavors { get; set; }
    
    public SweetsAndTreatsContext(DbContextOptions options) : base(options) { }
  }
}