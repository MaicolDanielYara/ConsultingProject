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
    public class ProyectoesController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public ProyectoesController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Proyectoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proyecto.ToListAsync());
        }

        // GET: Proyectoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyecto
                .FirstOrDefaultAsync(m => m.IdProyecto == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProyecto,NombreProyecto,NoConvenio,Objeto,FechaInicio,PlazoEjecucion,Presupuesto")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyecto.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdProyecto,NombreProyecto,NoConvenio,Objeto,FechaInicio,PlazoEjecucion,Presupuesto")] Proyecto proyecto)
        {
            if (id != proyecto.IdProyecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectoExists(proyecto.IdProyecto))
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
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyecto
                .FirstOrDefaultAsync(m => m.IdProyecto == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);
            _context.Proyecto.Remove(proyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(string id)
        {
            return _context.Proyecto.Any(e => e.IdProyecto == id);
        }
    }
}
