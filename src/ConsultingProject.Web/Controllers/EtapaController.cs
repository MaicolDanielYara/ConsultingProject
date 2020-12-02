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
    public class EtapaController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public EtapaController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Etapas
        public async Task<IActionResult> Index()
        {
            var consultingProjectDbContext = _context.Etapas.Include(e => e.IdProyectoNavigation);
            return View(await consultingProjectDbContext.ToListAsync());
        }

        // GET: Etapas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapas = await _context.Etapas
                .Include(e => e.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdEtapa == id);
            if (etapas == null)
            {
                return NotFound();
            }

            return View(etapas);
        }

        // GET: Etapas/Create
        public IActionResult Create()
        {
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto");
            return View();
        }

        // POST: Etapas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEtapa,NombreEtapa,DescripcionEtapa,IdProyecto")] Etapas etapas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etapas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", etapas.IdProyecto);
            return View(etapas);
        }

        // GET: Etapas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapas = await _context.Etapas.FindAsync(id);
            if (etapas == null)
            {
                return NotFound();
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", etapas.IdProyecto);
            return View(etapas);
        }

        // POST: Etapas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdEtapa,NombreEtapa,DescripcionEtapa,IdProyecto")] Etapas etapas)
        {
            if (id != etapas.IdEtapa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etapas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtapasExists(etapas.IdEtapa))
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
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", etapas.IdProyecto);
            return View(etapas);
        }

        // GET: Etapas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapas = await _context.Etapas
                .Include(e => e.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdEtapa == id);
            if (etapas == null)
            {
                return NotFound();
            }

            return View(etapas);
        }

        // POST: Etapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var etapas = await _context.Etapas.FindAsync(id);
            _context.Etapas.Remove(etapas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtapasExists(string id)
        {
            return _context.Etapas.Any(e => e.IdEtapa == id);
        }
    }
}
