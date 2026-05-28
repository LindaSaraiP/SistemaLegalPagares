using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SistemaLegalPagares.Models;

namespace SistemaLegalPagares.Services.Pdf
{
    public class PagarePdfDocument : IDocument
    {
        private readonly Pagare _pagare;

        public PagarePdfDocument(Pagare pagare)
        {
            _pagare = pagare;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(40);

                page.Header()
                    .Text("PAGARÉ")
                    .Bold()
                    .FontSize(20)
                    .AlignCenter();

                page.Content()
                    .Column(col =>
                    {
                        col.Item().Text($"Expediente: {_pagare.NumeroExpediente}");
                        col.Item().Text($"Monto: ${_pagare.Monto}");
                        col.Item().Text($"Beneficiario: {_pagare.NombreBeneficiario}");
                        col.Item().Text($"Suscriptor: {_pagare.NombreSuscriptor}");
                        col.Item().Text($"Lugar de pago: {_pagare.LugarPago}");
                        col.Item().Text($"Fecha de pago: {_pagare.FechaPago}");
                        col.Item().Text($"Lugar de suscripción: {_pagare.LugarSuscripcion}");
                        col.Item().Text($"Fecha de suscripción: {_pagare.FechaSuscripcion}");

                        col.Item().PaddingTop(20).Text("Firma del suscriptor:");
                        col.Item().Text(_pagare.FirmaSuscriptor).Bold();
                    });

                page.Footer()
                    .AlignCenter()
                    .Text($"Generado por Sistema Legal - {DateTime.Now}");
            });
        }
    }
}