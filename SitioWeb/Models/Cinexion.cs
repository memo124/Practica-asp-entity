using Microsoft.EntityFrameworkCore;
namespace SitioWeb.Models
{
    public class Cinexion : DbContext
    {
        public DbSet<Estudiante> estudiantes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-O8SAEK9T;database=estudiantes;user=sa;password=sa;Encrypt=true;TrustServerCertificate=true;Integrated Security=false;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>().ToTable("estudiante", schema: "dbo");
        }
    }
}
