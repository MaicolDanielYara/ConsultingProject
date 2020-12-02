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
    public class ActividadController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public ActividadController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Actividades
        public async Task<IActionResult> Index()
        {
            var consultingProjectDbContext = _context.Actividades.Include(a => a.IdEtapaNavigation).Include(a => a.IdProfesionalNavigation).Include(a => a.IdProyectoNavigation);
            return View(await consultingProjectDbContext.ToListAsync());
        }

        // GET: Actividades/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades
                .Include(a => a.IdEtapaNavigation)
                .Include(a => a.IdProfesionalNavigation)
                .Include(a => a.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdActividad == id);
            if (actividades == null)
            {
                return NotFound();
            }

            return View(actividades);
        }

        // GET: Actividades/Create
        public IActionResult Create()
        {
            ViewData["IdEtapa"] = new SelectList(_context.Etapas, "IdEtapa", "IdEtapa");
            ViewData["IdProfesional"] = new SelectList(_context.Profesional, "IdProfesional", "IdProfesional");
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto");
            return View();
        }

        // POST: Actividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActividad,NombreActividad,DescripcionActividad,IdEtapa,IdProyecto,IdProfesional")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEtapa"] = new SelectList(_context.Etapas, "IdEtapa", "IdEtapa", actividades.IdEtapa);
            ViewData["IdProfesional"] = new SelectList(_context.Profesional, "IdProfesional", "IdProfesional", actividades.IdProfesional);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", actividades.IdProyecto);
            return View(actividades);
        }

        // GET: Actividades/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades.FindAsync(id);
            if (actividades == null)
            {
                return NotFound();
            }
            ViewData["IdEtapa"] = new SelectList(_context.Etapas, "IdEtapa", "IdEtapa", actividades.IdEtapa);
            ViewData["IdProfesional"] = new SelectList(_context.Profesional, "IdProfesional", "IdProfesional", actividades.IdProfesional);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", actividades.IdProyecto);
            return View(actividades);
        }

        // POST: Actividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdActividad,NombreActividad,DescripcionActividad,IdEtapa,IdProyecto,IdProfesional")] Actividades actividades)
        {
            if (id != actividades.IdActividad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadesExists(actividades.IdActividad))
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
            ViewData["IdEtapa"] = new SelectList(_context.Etapas, "IdEtapa", "IdEtapa", actividades.IdEtapa);
            ViewData["IdProfesional"] = new SelectList(_context.Profesional, "IdProfesional", "IdProfesional", actividades.IdProfesional);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", actividades.IdProyecto);
            return View(actividades);
        }

        // GET: Actividades/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades
                .Include(a => a.IdEtapaNavigation)
                .Include(a => a.IdProfesionalNavigation)
                .Include(a => a.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdActividad == id);
            if (actividades == null)
            {
                return NotFound();
            }

            return View(actividades);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var actividades = await _context.Actividades.FindAsync(id);
            _context.Actividades.Remove(actividades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadesExists(string id)
        {
            return _context.Actividades.Any(e => e.IdActividad == id);
        }
    }
}
