using Lib.Models.Product;
using Lib.Models.Obtain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Surfboard> Surfboard { get; set; } = default!;

        //public DbSet<Bought> Bought { get; set; } = default!;
        public DbSet<Rental> Rental { get; set; } = default!;
    }
}
