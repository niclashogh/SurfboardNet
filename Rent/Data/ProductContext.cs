using Lib.Models.Product;
using Lib.Models.Obtain;
using Microsoft.EntityFrameworkCore;

namespace Rent.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Surfboard> Surfboard { get; set; } = default!;
        public DbSet<Rental> Rental { get; set; } = default!;
    }
}
