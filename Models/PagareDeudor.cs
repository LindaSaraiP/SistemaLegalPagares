
namespace SistemaLegalPagares.Models
{
    public class PagareDeudor
    {
        public int PagareId { get; set; }

        public Pagare? Pagare { get; set; }

        public int DeudorId { get; set; }

        public Deudor? Deudor { get; set; }
    }
}