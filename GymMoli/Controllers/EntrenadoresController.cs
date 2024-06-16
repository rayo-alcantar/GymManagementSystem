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
    public class EntrenadoresController : Controller
    {
        private readonly GymDbContext _context;

        public EntrenadoresController(GymDbContext context)
        {
            _context = context;
        }

        // GET: Entrenadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entrenadores.ToListAsync());
        }

        // GET: Entrenadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrenadores = await _context.Entrenadores
                .FirstOrDefaultAsync(m => m.ID_Entrenador == id);
            if (entrenadores == null)
            {
                return NotFound();
            }

            return View(entrenadores);
        }

        // GET: Entrenadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entrenadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Entrenador,Nombre,Apellido,Especialidad,Teléfono,Email")] Entrenadores entrenadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrenadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrenadores);
        }

        // GET: Entrenadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrenadores = await _context.Entrenadores.FindAsync(id);
            if (entrenadores == null)
            {
                return NotFound();
            }
            return View(entrenadores);
        }

        // POST: Entrenadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Entrenador,Nombre,Apellido,Especialidad,Teléfono,Email")] Entrenadores entrenadores)
        {
            if (id != entrenadores.ID_Entrenador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrenadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrenadoresExists(entrenadores.ID_Entrenador))
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
            return View(entrenadores);
        }

        // GET: Entrenadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrenadores = await _context.Entrenadores
                .FirstOrDefaultAsync(m => m.ID_Entrenador == id);
            if (entrenadores == null)
            {
                return NotFound();
            }

            return View(entrenadores);
        }

        // POST: Entrenadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrenadores = await _context.Entrenadores.FindAsync(id);
            if (entrenadores != null)
            {
                _context.Entrenadores.Remove(entrenadores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrenadoresExists(int id)
        {
            return _context.Entrenadores.Any(e => e.ID_Entrenador == id);
        }
    }
}
