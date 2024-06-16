using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GymMoli.Models
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Membresias> Membresias { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<Clases> Clases { get; set; }
        public DbSet<Entrenadores> Entrenadores { get; set; }
        public DbSet<Clases_Entrenadores> Clases_Entrenadores { get; set; }
        public DbSet<Asistencias> Asistencias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Build configuration
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Get connection string
                var connectionString = configuration.GetConnectionString("Connection");

                // Use the connection string
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir relaciones entre las entidades si es necesario

            // Relación entre Inscripción y Cliente
            modelBuilder.Entity<Inscripciones>()
                .HasOne(i => i.Cliente)
                .WithMany()
                .HasForeignKey(i => i.ID_Cliente);

            // Relación entre Inscripción y Membresía
            modelBuilder.Entity<Inscripciones>()
                .HasOne(i => i.Membresía)
                .WithMany()
                .HasForeignKey(i => i.ID_Membresía);

            // Relación entre Clase_Entrenador y Clase
            modelBuilder.Entity<Clases_Entrenadores>()
                .HasOne(ce => ce.Clase)
                .WithMany(c => c.Clases_Entrenadores)
                .HasForeignKey(ce => ce.ID_Clase);

            // Relación entre Clase_Entrenador y Entrenador
            modelBuilder.Entity<Clases_Entrenadores>()
                .HasOne(ce => ce.Entrenador)
                .WithMany(e => e.Clases_Entrenadores)
                .HasForeignKey(ce => ce.ID_Entrenador);

            // Relación entre Asistencia y Clase
            modelBuilder.Entity<Asistencias>()
                .HasOne(a => a.Clase)
                .WithMany(c => c.Asistencias)
                .HasForeignKey(a => a.ID_Clase);

            // Relación entre Asistencia y Cliente
            modelBuilder.Entity<Asistencias>()
                .HasOne(a => a.Cliente)
                .WithMany()
                .HasForeignKey(a => a.ID_Cliente);
        }
    }
}
