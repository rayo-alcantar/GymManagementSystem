using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymMoli.Models;

namespace GymMoli.Controllers
{
    public class InscripcionesController : Controller
    {
        private readonly GymDbContext _context;

        public InscripcionesController(GymDbContext context)
        {
            _context = context;
        }

        // GET: Inscripciones
        public async Task<IActionResult> Index()
        {
            var gymDbContext = _context.Inscripciones.Include(i => i.Cliente).Include(i => i.Membresía);
            return View(await gymDbContext.ToListAsync());
        }

        // GET: Inscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones
                .Include(i => i.Cliente)
                .Include(i => i.Membresía)
                .FirstOrDefaultAsync(m => m.ID_Inscripción == id);
            if (inscripciones == null)
            {
                return NotFound();
            }

            return View(inscripciones);
        }

        // GET: Inscripciones/Create
        public IActionResult Create()
        {
            ViewData["ID_Cliente"] = new SelectList(_context.Clientes, "ID_Cliente", "Apellido");
            ViewData["ID_Membresía"] = new SelectList(_context.Membresias, "ID_Membresía", "Tipo_Membresía");
            return View();
        }

        // POST: Inscripciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Inscripción,ID_Cliente,ID_Membresía,Fecha_Inicio,Fecha_Fin,Estado")] Inscripciones inscripciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Cliente"] = new SelectList(_context.Clientes, "ID_Cliente", "Apellido", inscripciones.ID_Cliente);
            ViewData["ID_Membresía"] = new SelectList(_context.Membresias, "ID_Membresía", "Tipo_Membresía", inscripciones.ID_Membresía);
            return View(inscripciones);
        }

        // GET: Inscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones.FindAsync(id);
            if (inscripciones == null)
            {
                return NotFound();
            }
            ViewData["ID_Cliente"] = new SelectList(_context.Clientes, "ID_Cliente", "Apellido", inscripciones.ID_Cliente);
            ViewData["ID_Membresía"] = new SelectList(_context.Membresias, "ID_Membresía", "Tipo_Membresía", inscripciones.ID_Membresía);
            return View(inscripciones);
        }

        // POST: Inscripciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Inscripción,ID_Cliente,ID_Membresía,Fecha_Inicio,Fecha_Fin,Estado")] Inscripciones inscripciones)
        {
            if (id != inscripciones.ID_Inscripción)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionesExists(inscripciones.ID_Inscripción))
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
            ViewData["ID_Cliente"] = new SelectList(_context.Clientes, "ID_Cliente", "Apellido", inscripciones.ID_Cliente);
            ViewData["ID_Membresía"] = new SelectList(_context.Membresias, "ID_Membresía", "Tipo_Membresía", inscripciones.ID_Membresía);
            return View(inscripciones);
        }

        // GET: Inscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones
                .Include(i => i.Cliente)
                .Include(i => i.Membresía)
                .FirstOrDefaultAsync(m => m.ID_Inscripción == id);
            if (inscripciones == null)
            {
                return NotFound();
            }

            return View(inscripciones);
        }

        // POST: Inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripciones = await _context.Inscripciones.FindAsync(id);
            if (inscripciones != null)
            {
                _context.Inscripciones.Remove(inscripciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionesExists(int id)
        {
            return _context.Inscripciones.Any(e => e.ID_Inscripción == id);
        }
    }
}
