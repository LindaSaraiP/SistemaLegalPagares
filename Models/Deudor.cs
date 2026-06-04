using System.ComponentModel.DataAnnotations;

namespace SistemaLegalPagares.Models
{
    public class Deudor
    {
        public int Id { get; set; }

        [Required]
        public string NombreCompleto { get; set; } = string.Empty;

        public string? CURP { get; set; }

        public string? INE { get; set; }

        public string? RFC { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Direccion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}