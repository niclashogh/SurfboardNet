using Lib.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lib.Services.Data
{
    public class CustomerContext : IdentityDbContext<Customer>
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
