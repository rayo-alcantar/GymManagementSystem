using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymMoli.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GymMoli.Controllers
{
    public class Clases_EntrenadoresController : Controller
    {
        private readonly GymDbContext _context;

        public Clases_EntrenadoresController(GymDbContext context)
        {
            _context = context;
        }

        // GET: Clases_Entrenadores
        public async Task<IActionResult> Index()
        {
            var gymDbContext = _context.Clases_Entrenadores.Include(c => c.Clase).Include(c => c.Entrenador);
            return View(await gymDbContext.ToListAsync());
        }

        // GET: Clases_Entrenadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clases_Entrenadores = await _context.Clases_Entrenadores
                .Include(c => c.Clase)
                .Include(c => c.Entrenador)
                .FirstOrDefaultAsync(m => m.ID_Clase_Entrenador == id);
            if (clases_Entrenadores == null)
            {
                return NotFound();
            }

            return View(clases_Entrenadores);
        }

        // GET: Clases_Entrenadores/Create
        public IActionResult Create()
        {
            ViewData["ID_Clase"] = new SelectList(_context.Clases, "ID_Clase", "Nombre_Clase");
            ViewData["ID_Entrenador"] = new SelectList(_context.Entrenadores, "ID_Entrenador", "Nombre");
            return View(new Clases_Entrenadores());
        }

        // POST: Clases_Entrenadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Clase_Entrenador,ID_Clase,ID_Entrenador")] Clases_Entrenadores clases_Entrenadores)
        {
            // Agregar información de depuración
            ViewBag.DebugInfo = $"ModelState.IsValid: {ModelState.IsValid}";

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(clases_Entrenadores);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.DebugInfo += $"\nException: {ex.Message}";
                }
            }
            else
            {
                ViewBag.DebugInfo += "\nModelState is not valid. Errors: " + string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            ViewData["ID_Clase"] = new SelectList(_context.Clases, "ID_Clase", "Nombre_Clase", clases_Entrenadores.ID_Clase);
            ViewData["ID_Entrenador"] = new SelectList(_context.Entrenadores, "ID_Entrenador", "Nombre", clases_Entrenadores.ID_Entrenador);
            return View(clases_Entrenadores);
        }

        // GET: Clases_Entrenadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clases_Entrenadores = await _context.Clases_Entrenadores.FindAsync(id);
            if (clases_Entrenadores == null)
            {
                return NotFound();
            }
            ViewData["ID_Clase"] = new SelectList(_context.Clases, "ID_Clase", "Nombre_Clase", clases_Entrenadores.ID_Clase);
            ViewData["ID_Entrenador"] = new SelectList(_context.Entrenadores, "ID_Entrenador", "Nombre", clases_Entrenadores.ID_Entrenador);
            return View(clases_Entrenadores);
        }

        // POST: Clases_Entrenadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Clase_Entrenador,ID_Clase,ID_Entrenador")] Clases_Entrenadores clases_Entrenadores)
        {
            if (id != clases_Entrenadores.ID_Clase_Entrenador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clases_Entrenadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Clases_EntrenadoresExists(clases_Entrenadores.ID_Clase_Entrenador))
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
            ViewData["ID_Clase"] = new SelectList(_context.Clases, "ID_Clase", "Nombre_Clase", clases_Entrenadores.ID_Clase);
            ViewData["ID_Entrenador"] = new SelectList(_context.Entrenadores, "ID_Entrenador", "Nombre", clases_Entrenadores.ID_Entrenador);
            return View(clases_Entrenadores);
        }

        // GET: Clases_Entrenadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clases_Entrenadores = await _context.Clases_Entrenadores
                .Include(c => c.Clase)
                .Include(c => c.Entrenador)
                .FirstOrDefaultAsync(m => m.ID_Clase_Entrenador == id);
            if (clases_Entrenadores == null)
            {
                return NotFound();
            }

            return View(clases_Entrenadores);
        }

        // POST: Clases_Entrenadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clases_Entrenadores = await _context.Clases_Entrenadores.FindAsync(id);
            if (clases_Entrenadores != null)
            {
                _context.Clases_Entrenadores.Remove(clases_Entrenadores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Clases_EntrenadoresExists(int id)
        {
            return _context.Clases_Entrenadores.Any(e => e.ID_Clase_Entrenador == id);
        }
    }
}
