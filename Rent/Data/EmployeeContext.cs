using Lib.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Rent.Data
{
    public class EmployeeContext : IdentityDbContext<Employee>
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; } = default!;
    }
}
