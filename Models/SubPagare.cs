using System.ComponentModel.DataAnnotations;

namespace SistemaLegalPagares.Models
{
    public class SubPagare
    {
        public int Id { get; set; }

        public int PagareId { get; set; }

        public Pagare? Pagare { get; set; }

        public int Numero { get; set; }

        public decimal Monto { get; set; }

        public DateTime FechaVencimiento { get; set; }
    }
}