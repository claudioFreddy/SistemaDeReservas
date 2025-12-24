using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeReservas.Models // ← reemplaza con tu espacio de nombres real
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        public string Motivo { get; set; } = string.Empty;

        public string Estado { get; set; } = "Pendiente";

        // Relación con el usuario
        public string? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public ApplicationUser? Usuario { get; set; }
    }
}

