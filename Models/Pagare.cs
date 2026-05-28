using System.ComponentModel.DataAnnotations;

namespace SistemaLegalPagares.Models
{
    public class Pagare
    {
        public int Id { get; set; }

        // Número de expediente interno
        [Required]
        [Display(Name = "Número de Expediente")]
        public string NumeroExpediente { get; set; }

        // II - Promesa de pago
        [Required]
        [Display(Name = "Monto a Pagar")]
        public decimal Monto { get; set; }

        // III - Beneficiario
        [Required]
        [Display(Name = "Nombre del Beneficiario")]
        public string NombreBeneficiario { get; set; }

        // Suscriptor / deudor
        [Required]
        [Display(Name = "Nombre del Suscriptor")]
        public string NombreSuscriptor { get; set; }

        // IV - Lugar de pago
        [Required]
        [Display(Name = "Lugar de Pago")]
        public string LugarPago { get; set; }

        // IV - Fecha de pago
        [Required]
        [Display(Name = "Fecha de Pago")]
        public DateTime FechaPago { get; set; }

        // V - Lugar de firma
        [Required]
        [Display(Name = "Lugar de Suscripción")]
        public string LugarSuscripcion { get; set; }

        // V - Fecha de firma
        [Required]
        [Display(Name = "Fecha de Suscripción")]
        public DateTime FechaSuscripcion { get; set; }

        // VI - Firma
        [Required]
        [Display(Name = "Firma del Suscriptor")]
        public string FirmaSuscriptor { get; set; }

        // Usuario creador
        public string UsuarioId { get; set; }
    }
}