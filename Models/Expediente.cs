using System.ComponentModel.DataAnnotations;

namespace SistemaLegalPagares.Models
{
    public class Expediente
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Número de Expediente")]
        public string NumeroExpediente { get; set; } = string.Empty;

        // Nueva relación con Cliente
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Campos legacy del expediente
        // Los dejamos por ahora para no romper vistas anteriores
        public string? NombreCliente { get; set; }

        public string? CURP { get; set; }

        public string? INE { get; set; }

        public string? RFC { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string? Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public ICollection<Pagare>? Pagares { get; set; }
    }
}