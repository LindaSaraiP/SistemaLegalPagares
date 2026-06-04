using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaLegalPagares.Data;
using SistemaLegalPagares.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaLegalPagares.Controllers
{
    public class ExpedientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpedientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expedientes
        public async Task<IActionResult> Index()
        {
            var expedientes = await _context.Expedientes
                .Include(e => e.Cliente)
                .ToListAsync();

            return View(expedientes);
        }

        // GET: Expedientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes
                .Include(e => e.Cliente)
                .Include(e => e.Pagares)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // GET: Expedientes/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(
                _context.Clientes.ToList(),
                "Id",
                "NombreCompleto"
            );

            return View();
        }

        // POST: Expedientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                expediente.FechaCreacion = DateTime.Now;

                _context.Expedientes.Add(expediente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = new SelectList(
                _context.Clientes.ToList(),
                "Id",
                "NombreCompleto",
                expediente.ClienteId
            );

            return View(expediente);
        }

        // GET: Expedientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes.FindAsync(id);

            if (expediente == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = new SelectList(
                _context.Clientes.ToList(),
                "Id",
                "NombreCompleto",
                expediente.ClienteId
            );

            return View(expediente);
        }

        // POST: Expedientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Expediente expediente)
        {
            if (id != expediente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var expedienteDb = await _context.Expedientes.FindAsync(id);

                    if (expedienteDb == null)
                    {
                        return NotFound();
                    }

                    expedienteDb.NumeroExpediente = expediente.NumeroExpediente;
                    expedienteDb.ClienteId = expediente.ClienteId;
                    expedienteDb.Observaciones = expediente.Observaciones;

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedienteExists(expediente.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }
            }

            ViewBag.Clientes = new SelectList(
                _context.Clientes.ToList(),
                "Id",
                "NombreCompleto",
                expediente.ClienteId
            );

            return View(expediente);
        }

        // GET: Expedientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente != null)
            {
                _context.Expedientes.Remove(expediente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expedientes.Any(e => e.Id == id);
        }
    }
}
