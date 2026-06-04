using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLegalPagares.Data;
using SistemaLegalPagares.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SistemaLegalPagares.Services.Pdf;
using QuestPDF.Fluent;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaLegalPagares.Controllers
{
    [Authorize(Roles = "Admin,Abogado")]
    public class PagaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // LISTADO
        // =========================
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (User.IsInRole("Admin"))
            {
                return View(await _context.Pagares.ToListAsync());
            }

            return View(await _context.Pagares
                .Where(p => p.UsuarioId == userId)
                .ToListAsync());
        }

        // =========================
        // DETAILS
        // =========================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var pagare = await _context.Pagares.FirstOrDefaultAsync(p => p.Id == id);

            if (pagare == null) return NotFound();

            if (!User.IsInRole("Admin") && pagare.UsuarioId != userId)
                return Forbid();

            return View(pagare);
        }

        // =========================
        // CREATE GET
        // =========================
        public IActionResult Create(int? expedienteId)
        {
            CargarDeudoresViewBag();

            var pagare = new Pagare
            {
                ExpedienteId = expedienteId ?? 0,
                LugarExpedicion = "Puebla, Puebla",
                FechaExpedicion = DateTime.Now,
                NumeroPagare = "1 de 1",
                SerieDesde = 1,
                SerieHasta = 1
            };

            return View(pagare);
        }
        // =========================
        // CREATE POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pagare pagare)
        {
            // Datos automáticos
            pagare.UsuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            pagare.FechaExpedicion = DateTime.Now;
            pagare.LugarExpedicion = "Puebla, Puebla";

            // Compatibilidad con campos legacy
            pagare.Beneficiario = pagare.NombreSuscriptor;
            pagare.NombreBeneficiario = pagare.NombreSuscriptor;
            pagare.Acreedor = pagare.NombreSuscriptor ?? "Sin deudor";

            pagare.Monto = pagare.MontoTotal;
            pagare.FechaPago = pagare.FechaVencimiento;
            pagare.LugarPago = pagare.LugarPagoPagare;
            pagare.LugarSuscripcion = pagare.LugarExpedicion;
            pagare.FechaSuscripcion = pagare.FechaExpedicion;
            pagare.FirmaSuscriptor = "Firma digital capturada";

            if (pagare.FechaVencimiento.Date < DateTime.Today)
            {
                ModelState.AddModelError("FechaVencimiento", "La fecha de vencimiento no puede ser anterior al día actual.");
            }

            // Si no viene expediente, marcamos error claro
            if (pagare.ExpedienteId <= 0)
            {
                ModelState.AddModelError("ExpedienteId", "No se recibió el expediente asociado al pagaré.");
            }

            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                TempData["Error"] = "No se pudo guardar el pagaré: " + string.Join(" | ", errores);

                CargarDeudoresViewBag();

                return View(pagare);
            }

            _context.Pagares.Add(pagare);
            await _context.SaveChangesAsync();

            TempData["Success"] = "El pagaré se guardó correctamente.";

            return RedirectToAction(nameof(Details), new { id = pagare.Id });
        }

        // =========================
        // EDIT GET
        // =========================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pagare = await _context.Pagares.FindAsync(id);

            if (pagare == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.IsInRole("Admin") && pagare.UsuarioId != userId)
                return Forbid();

            return View(pagare);
        }

        // =========================
        // EDIT POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroExpediente,Monto,NombreBeneficiario,NombreSuscriptor,LugarPago,FechaPago,LugarSuscripcion,FechaSuscripcion,FirmaSuscriptor")] Pagare pagare)
        {
            if (id != pagare.Id) return NotFound();

            var pagareDb = await _context.Pagares.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pagareDb == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.IsInRole("Admin") && pagareDb.UsuarioId != userId)
                return Forbid();

            if (ModelState.IsValid)
            {
                pagare.UsuarioId = pagareDb.UsuarioId;

                _context.Update(pagare);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(pagare);
        }

        // =========================
        // DELETE GET
        // =========================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pagare = await _context.Pagares.FirstOrDefaultAsync(p => p.Id == id);

            if (pagare == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.IsInRole("Admin") && pagare.UsuarioId != userId)
                return Forbid();

            return View(pagare);
        }

        // =========================
        // DELETE POST
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagare = await _context.Pagares.FindAsync(id);

            if (pagare == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.IsInRole("Admin") && pagare.UsuarioId != userId)
                return Forbid();

            _context.Pagares.Remove(pagare);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PagareExists(int id)
        {
            return _context.Pagares.Any(e => e.Id == id);
        }

        //PDF
        public async Task<IActionResult> Pdf(int id)
        {
            var pagare = await _context.Pagares.FindAsync(id);

            if (pagare == null)
                return NotFound();

            var document = new PagarePdfDocument(pagare);

            var pdf = document.GeneratePdf();

            return File(pdf, "application/pdf", $"Pagare_{pagare.NumeroExpediente}.pdf");
        }


        //post respaldo

        private void CargarDeudoresViewBag()
        {
            var deudores = _context.Deudores.ToList();

            ViewBag.Deudores = deudores.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.NombreCompleto
            }).ToList();

            ViewBag.DeudoresJson = System.Text.Json.JsonSerializer.Serialize(
                deudores.Select(d => new
                {
                    id = d.Id,
                    nombre = d.NombreCompleto,
                    domicilio = d.Direccion,
                    poblacion = d.Poblacion
                })
            );
        }

    }
}