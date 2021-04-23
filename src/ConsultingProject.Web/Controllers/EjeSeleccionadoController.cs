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
    public class EjeSeleccionadoController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public EjeSeleccionadoController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: EjeSeleccionadoes
        public async Task<IActionResult> Index()
        {
            var consultingProjectDbContext = _context.EjeSeleccionado.Include(e => e.IdProyectoNavigation);
            return View(await consultingProjectDbContext.ToListAsync());
        }

        // GET: EjeSeleccionadoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejeSeleccionado = await _context.EjeSeleccionado
                .Include(e => e.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdEje == id);
            if (ejeSeleccionado == null)
            {
                return NotFound();
            }

            return View(ejeSeleccionado);
        }

        // GET: EjeSeleccionadoes/Create
        public IActionResult Create()
        {
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto");
            return View();
        }

        // POST: EjeSeleccionadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEje,Eje,IdProyecto")] EjeSeleccionado ejeSeleccionado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejeSeleccionado);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El Eje se ha creado correctamente";
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", ejeSeleccionado.IdProyecto);
            return View(ejeSeleccionado);
        }

        // GET: EjeSeleccionadoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejeSeleccionado = await _context.EjeSeleccionado.FindAsync(id);
            if (ejeSeleccionado == null)
            {
                return NotFound();
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", ejeSeleccionado.IdProyecto);
            return View(ejeSeleccionado);
        }

        // POST: EjeSeleccionadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdEje,Eje,IdProyecto")] EjeSeleccionado ejeSeleccionado)
        {
            if (id != ejeSeleccionado.IdEje)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejeSeleccionado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjeSeleccionadoExists(ejeSeleccionado.IdEje))
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
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", ejeSeleccionado.IdProyecto);
            return View(ejeSeleccionado);
        }

        // GET: EjeSeleccionadoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejeSeleccionado = await _context.EjeSeleccionado
                .Include(e => e.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdEje == id);
            if (ejeSeleccionado == null)
            {
                return NotFound();
            }

            return View(ejeSeleccionado);
        }

        // POST: EjeSeleccionadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ejeSeleccionado = await _context.EjeSeleccionado.FindAsync(id);
            _context.EjeSeleccionado.Remove(ejeSeleccionado);
            await _context.SaveChangesAsync();
            TempData["MensajeEliminar"] = "El Eje Seleccionado se ha eliminado correctamente";
            return RedirectToAction(nameof(Index));
        }

        private bool EjeSeleccionadoExists(string id)
        {
            return _context.EjeSeleccionado.Any(e => e.IdEje == id);
        }
    }
}
