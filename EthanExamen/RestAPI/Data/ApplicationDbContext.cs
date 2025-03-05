
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models.Entity;

namespace RestAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*Relacion one to many con dicatadores*/
            modelBuilder.Entity<AutorEntity>().HasMany(e => e.Dicatador).WithOne(e => e.Autor).HasForeignKey(e => e.Id_autor).IsRequired();

            /*Relacion many to many con dicatadores*/
            modelBuilder.Entity<GrupoEntity>().HasMany(e => e.Dicatadores).WithMany(e => e.Grupos);

        }
        //Add models here
        public DbSet<DicatadorEntity> Dictadors { get; set; }
        public DbSet<GrupoEntity> Grupo { get; set; }
        public DbSet<AutorEntity> Autor { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        

    }
}
