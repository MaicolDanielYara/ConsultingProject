using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultingProject.Core.Domain;
using ConsultingProject.Infrastructure.Data;

namespace ConsultingProject.Web.Controllers
{
    public class HerramientaController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public HerramientaController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Herramientas
        public async Task<IActionResult> Index()
        {
            var consultingProjectDbContext = _context.Herramientas.Include(h => h.IdEjeNavigation);
            return View(await consultingProjectDbContext.ToListAsync());
        }

        // GET: Herramientas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herramientas = await _context.Herramientas
                .Include(h => h.IdEjeNavigation)
                .FirstOrDefaultAsync(m => m.IdHerramienta == id);
            if (herramientas == null)
            {
                return NotFound();
            }

            return View(herramientas);
        }

        // GET: Herramientas/Create
        public IActionResult Create()
        {
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje");
            return View();
        }

        // POST: Herramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHerramienta,Herramienta,IdEje")] Herramientas herramientas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(herramientas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", herramientas.IdEje);
            return View(herramientas);
        }

        // GET: Herramientas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herramientas = await _context.Herramientas.FindAsync(id);
            if (herramientas == null)
            {
                return NotFound();
            }
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", herramientas.IdEje);
            return View(herramientas);
        }

        // POST: Herramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdHerramienta,Herramienta,IdEje")] Herramientas herramientas)
        {
            if (id != herramientas.IdHerramienta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herramientas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerramientasExists(herramientas.IdHerramienta))
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
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", herramientas.IdEje);
            return View(herramientas);
        }

        // GET: Herramientas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herramientas = await _context.Herramientas
                .Include(h => h.IdEjeNavigation)
                .FirstOrDefaultAsync(m => m.IdHerramienta == id);
            if (herramientas == null)
            {
                return NotFound();
            }

            return View(herramientas);
        }

        // POST: Herramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var herramientas = await _context.Herramientas.FindAsync(id);
            _context.Herramientas.Remove(herramientas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerramientasExists(string id)
        {
            return _context.Herramientas.Any(e => e.IdHerramienta == id);
        }
    }
}
