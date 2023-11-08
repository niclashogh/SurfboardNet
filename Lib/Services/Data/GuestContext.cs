using Lib.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Data
{
    public class GuestContext : IdentityDbContext
    {
        public GuestContext(DbContextOptions<GuestContext> options) : base(options)
        {
        }
        public DbSet<Guest> Guest { get; set; }
    }
}
