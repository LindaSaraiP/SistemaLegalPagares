using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaLegalPagares.Models
{
    public class Pagare
    {
        public int Id { get; set; }

        // =========================
        // RELACIÓN CON EXPEDIENTE
        // =========================
        public int ExpedienteId { get; set; }
        public Expediente? Expediente { get; set; }

        // =========================
        // DATOS PRINCIPALES
        // =========================
        [Display(Name = "Número de Pagaré")]
        public string? NumeroPagare { get; set; }

        [Required]
        [Display(Name = "Lugar de Expedición")]
        public string LugarExpedicion { get; set; } = "Puebla, Puebla";

        [Required]
        [Display(Name = "Fecha de Expedición")]
        public DateTime FechaExpedicion { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Acreedor")]
        public string Acreedor { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Monto Total")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoTotal { get; set; }

        [Display(Name = "Monto en Letra")]
        public string? MontoLetra { get; set; }

        [Required]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        // =========================
        // DATOS FORMITEC
        // =========================
        [Display(Name = "Beneficiario")]
        public string? Beneficiario { get; set; }

        [Display(Name = "Lugar de Pago")]
        public string? LugarPagoPagare { get; set; }

        [Display(Name = "Serie Desde")]
        public int SerieDesde { get; set; } = 1;

        [Display(Name = "Serie Hasta")]
        public int SerieHasta { get; set; } = 1;

        [Display(Name = "Interés Moratorio")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? InteresMoratorio { get; set; }

        [Display(Name = "Texto Legal")]
        public string? TextoLegal { get; set; }

        [Display(Name = "Firma")]
        public string? FirmaBase64 { get; set; }

        public string? UsuarioId { get; set; }

        // =========================
        // RELACIONES
        // =========================
        public ICollection<SubPagare>? SubPagares { get; set; }

        public ICollection<PagareDeudor>? PagareDeudores { get; set; }

        // =========================
        // CAMPOS LEGACY
        // NO BORRAR TODAVÍA
        // =========================
        public string? NumeroExpediente { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Monto { get; set; }

        public string? NombreBeneficiario { get; set; }

        public string? NombreSuscriptor { get; set; }

        public string? LugarPago { get; set; }

        public DateTime? FechaPago { get; set; }

        public string? LugarSuscripcion { get; set; }

        public DateTime? FechaSuscripcion { get; set; }

        public string? FirmaSuscriptor { get; set; }

        public string? DomicilioDeudor { get; set; }

        public string? PoblacionDeudor { get; set; }
    }
}