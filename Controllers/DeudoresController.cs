using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaLegalPagares.Data;
using SistemaLegalPagares.Models;

namespace SistemaLegalPagares.Controllers
{
    public class DeudoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeudoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deudores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deudores.ToListAsync());
        }

        // GET: Deudores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudor = await _context.Deudores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deudor == null)
            {
                return NotFound();
            }

            return View(deudor);
        }

        // GET: Deudores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deudores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,CURP,INE,RFC,Telefono,Correo,Direccion,Poblacion,FechaRegistro")] Deudor deudor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deudor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deudor);
        }

        // GET: Deudores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudor = await _context.Deudores.FindAsync(id);
            if (deudor == null)
            {
                return NotFound();
            }
            return View(deudor);
        }

        // POST: Deudores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,CURP,INE,RFC,Telefono,Correo,Direccion,Poblacion,FechaRegistro")] Deudor deudor)
        {
            if (id != deudor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deudor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeudorExists(deudor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deudor);
        }

        // GET: Deudores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudor = await _context.Deudores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deudor == null)
            {
                return NotFound();
            }

            return View(deudor);
        }

        // POST: Deudores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deudor = await _context.Deudores.FindAsync(id);
            if (deudor != null)
            {
                _context.Deudores.Remove(deudor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeudorExists(int id)
        {
            return _context.Deudores.Any(e => e.Id == id);
        }
    }
}
