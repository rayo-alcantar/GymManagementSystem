using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymMoli.Models;

namespace GymMoli.Controllers
{
    public class AsistenciasController : Controller
    {
        private readonly GymDbContext _context;

        public AsistenciasController(GymDbContext context)
        {
            _context = context;
        }

        // GET: Asistencias
        public async Task<IActionResult> Index()
        {
            var gymDbContext = _context.Asistencias.Include(a => a.Clase).Include(a => a.Cliente);
            return View(await gymDbContext.ToListAsync());
        }

        // GET: Asistencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencias = await _context.Asistencias
                .Include(a => a.Clase)
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.ID_Asistencia == id);
            if (asistencias == null)
            {
                return NotFound();
            }

            return View(asistencias);
        }

        // GET: Asistencias/Create
        public IActionResult Create()
        {
            ViewData["ID_Clase"] = new SelectList(_context.Clases, "ID_Clase", "Día");
            ViewData["ID_Cliente"] = new SelectList(_context.Clientes, "ID_Cliente", "Apellido");
            return View(new Asistencias()); // Asegurarse de pasar un nuevo modelo a la vista
        }

        // POST: Asistencias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Asistencia,ID_Clase,ID_Cliente,Fecha_Asistencia")] Asistencias asistencias)
        {
            // Agregar información de depuración
            ViewBag.DebugInfo = $"ModelState.IsValid: {ModelState.IsValid}";

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(asistencias);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.DebugInfo += $"\nError: {ex.Message}\nStackTrace: {ex.StackTrace}";
                }
            }
            else
            {
                ViewBag.DebugInfo += "\nModelState is not valid. Errors: " + string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            ViewData["ID_Clase"] = new SelectList(_context.Clases, "ID_Clase", "Día", asistencias.ID_Clase);
            ViewData["ID_Cliente"] = new SelectList(_context.Clientes, "ID_Cliente", "Apellido", asistencias.ID_Cliente);
            return View(asistencias);
        }

        // GET: Asistencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencias = await _context.Asistencias.FindAsync(id);
            if (asistencias == null)
            {
                return NotFound();
            }
            ViewData["ID_Clase"] = new SelectList(_context.Clases, "ID_Clase", "Día", asistencias.ID_Clase);
            ViewData["ID_Cliente"] = new SelectList(_context.Clientes, "ID_Cliente", "Apellido", asistencias.ID_Cliente);
            return View(asistencias);
        }

        // POST: Asistencias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Asistencia,ID_Clase,ID_Cliente,Fecha_Asistencia")] Asistencias asistencias)
        {
            if (id != asistencias.ID_Asistencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciasExists(asistencias.ID_Asistencia))
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
            ViewData["ID_Clase"] = new SelectList(_context.Clases, "ID_Clase", "Día", asistencias.ID_Clase);
            ViewData["ID_Cliente"] = new SelectList(_context.Clientes, "ID_Cliente", "Apellido", asistencias.ID_Cliente);
            return View(asistencias);
        }

        // GET: Asistencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencias = await _context.Asistencias
                .Include(a => a.Clase)
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.ID_Asistencia == id);
            if (asistencias == null)
            {
                return NotFound();
            }

            return View(asistencias);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistencias = await _context.Asistencias.FindAsync(id);
            if (asistencias != null)
            {
                _context.Asistencias.Remove(asistencias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciasExists(int id)
        {
            return _context.Asistencias.Any(e => e.ID_Asistencia == id);
        }
    }
}
