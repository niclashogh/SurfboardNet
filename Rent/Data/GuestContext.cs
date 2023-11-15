using Lib.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Rent.Data
{
    public class GuestContext : IdentityDbContext
    {
        public GuestContext(DbContextOptions<GuestContext> options) : base(options) { }
        public DbSet<Guest> Guest { get; set; } = default!;
    }
}
