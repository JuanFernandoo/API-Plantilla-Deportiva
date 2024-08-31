using Microsoft.EntityFrameworkCore;

namespace FcBarcelona.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options) { }

        public DbSet<Barcelona> Plantilla { get; set; } // Tabla Plantilla
        public DbSet<Auditoria> Auditoria { get; set; } // Tabla Auditoria 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Barcelona>().HasIndex(c => c.Nombre).IsUnique();
        }
    }
}

