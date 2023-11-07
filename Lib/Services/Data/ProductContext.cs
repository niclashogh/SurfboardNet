using Lib.Models.Product;
using Lib.Models.Service;
using Lib.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lib.Services.Data
{
    public class ProductContext : IdentityDbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Bought> Bought { get; set; }
        public DbSet<Rental>? Rental { get; set; }

        public DbSet<Surfboard> Surfboard { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Guest> Guest { get; set; }
    }
}
