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
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // CREATE POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pagare pagare)
        {
            //  ASIGNAR USUARIO SIEMPRE DESDE EL SERVER
            pagare.UsuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // DEBUG: ver errores reales si falla
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Content("ModelState inválido: " + string.Join(" | ", errors));
            }

            try
            {
                _context.Pagares.Add(pagare);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // VER ERROR REAL DE BD
                return Content("Error al guardar: " + ex.Message);
            }
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

    }
}