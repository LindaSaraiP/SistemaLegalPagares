
using System.ComponentModel.DataAnnotations;

namespace SistemaLegalPagares.Models
{
    public class Expediente
    {
        public int Id { get; set; }

        [Required]
        public string NumeroExpediente { get; set; } = string.Empty;

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