using System.ComponentModel.DataAnnotations;

namespace SistemaLegalPagares.Models
{
    public class Pagare
    {
        public int Id { get; set; }

        // NUEVO MODELO
        public int ExpedienteId { get; set; }
        public Expediente? Expediente { get; set; }

        public string? NumeroPagare { get; set; }

        [Required]
        public string LugarExpedicion { get; set; } = "Cuernavaca, Morelos";

        [Required]
        public DateTime FechaExpedicion { get; set; } = DateTime.Now;

        [Required]
        public string Acreedor { get; set; } = string.Empty;

        [Required]
        public decimal MontoTotal { get; set; }

        public string? MontoLetra { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        public string? TextoLegal { get; set; }

        public string? FirmaBase64 { get; set; }

        public string? UsuarioId { get; set; }

        public ICollection<SubPagare>? SubPagares { get; set; }

        public ICollection<PagareDeudor>? PagareDeudores { get; set; }

        // CAMPOS LEGACY
        public string? NumeroExpediente { get; set; }

        public decimal? Monto { get; set; }

        public string? NombreBeneficiario { get; set; }

        public string? NombreSuscriptor { get; set; }

        public string? LugarPago { get; set; }

        public DateTime? FechaPago { get; set; }

        public string? LugarSuscripcion { get; set; }

        public DateTime? FechaSuscripcion { get; set; }

        public string? FirmaSuscriptor { get; set; }
    }
}