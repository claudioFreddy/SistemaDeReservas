using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.Models;

namespace SistemaDeReservas.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Importante para Identity

            // Configurar la relación Reserva ↔ Usuario
            builder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.UsuarioId);
        }
    }
}



/*namespace SistemaDeReservas.Data // ← Ajusta esto si usas otro namespace
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reserva> Reservas { get; set; }



        // Si tienes otros modelos, los agregas aquí:
        // public DbSet<OtroModelo> Otros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configurar relación entre Usuario y Reserva (opcional si usas anotaciones en el modelo)
            builder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany() // o .WithMany(u => u.Reservas) si agregas una lista en ApplicationUser
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}  */
