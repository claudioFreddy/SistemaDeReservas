using Microsoft.AspNetCore.Identity;

namespace SistemaDeReservas.Models // ← reemplaza por tu namespace real
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Reserva>? Reservas { get; set; }
        public string? NombreCompleto { get; set; }  // 👈 Campo personalizado

        // Aquí puedes agregar más propiedades si lo deseas:
        // public string NombreCompleto { get; set; }
    }
}

