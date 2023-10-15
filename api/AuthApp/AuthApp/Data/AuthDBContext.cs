using AuthApp.Config;
using AuthApp.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Data
{
    public class AuthDBContext : IdentityDbContext<User>
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options){  }
        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfig());           
        }
    }
}
