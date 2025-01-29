using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ferraro.Models.Entity;

namespace Ferraro.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //Add models here
        public DbSet<DicatadorEntity> Dictadors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
