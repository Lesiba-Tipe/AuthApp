using AuthApp.Config;
using AuthApp.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Data
{
    public class AuthBDContext : IdentityDbContext<User>
    {
        public AuthBDContext(DbContextOptions<AuthBDContext> options) : base(options){  }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
