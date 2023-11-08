using Lib.Models.Product;
using Lib.Models.Service;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lib.Services.Data
{
    public class ProductContext : IdentityDbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Surfboard> Surfboard { get; set; }

        public DbSet<Bought> Bought { get; set; }
        public DbSet<Rental> Rental { get; set; }

    }
}
