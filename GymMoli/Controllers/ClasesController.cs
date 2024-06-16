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
    public class ClasesController : Controller
    {
        private readonly GymDbContext _context;

        public ClasesController(GymDbContext context)
        {
            _context = context;
        }

        // GET: Clases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clases.ToListAsync());
        }

        // GET: Clases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clases = await _context.Clases
                .FirstOrDefaultAsync(m => m.ID_Clase == id);
            if (clases == null)
            {
                return NotFound();
            }

            return View(clases);
        }

        // GET: Clases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Clase,Nombre_Clase,Descripción,Día,Hora_Inicio,Hora_Fin,Capacidad")] Clases clases)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clases);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clases);
        }


        // GET: Clases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clases = await _context.Clases.FindAsync(id);
            if (clases == null)
            {
                return NotFound();
            }
            return View(clases);
        }

        // POST: Clases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Clase,Nombre_Clase,Descripción,Día,Hora_Inicio,Hora_Fin,Capacidad")] Clases clases)
        {
            if (id != clases.ID_Clase)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasesExists(clases.ID_Clase))
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
            return View(clases);
        }

        // GET: Clases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clases = await _context.Clases
                .FirstOrDefaultAsync(m => m.ID_Clase == id);
            if (clases == null)
            {
                return NotFound();
            }

            return View(clases);
        }

        // POST: Clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clases = await _context.Clases.FindAsync(id);
            if (clases != null)
            {
                _context.Clases.Remove(clases);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasesExists(int id)
        {
            return _context.Clases.Any(e => e.ID_Clase == id);
        }
    }
}
