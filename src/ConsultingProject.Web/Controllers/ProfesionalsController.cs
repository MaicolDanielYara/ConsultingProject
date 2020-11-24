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
    public class ProfesionalsController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public ProfesionalsController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Profesionals
        public async Task<IActionResult> Index()
        {
            var consultingProjectDbContext = _context.Profesional.Include(p => p.IdCargoNavigation).Include(p => p.IdEjeNavigation).Include(p => p.IdEstudioNavigation).Include(p => p.IdProfesionNavigation).Include(p => p.IdProyectoNavigation).Include(p => p.IdTipoDocumentoNavigation);
            return View(await consultingProjectDbContext.ToListAsync());
        }

        // GET: Profesionals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesional
                .Include(p => p.IdCargoNavigation)
                .Include(p => p.IdEjeNavigation)
                .Include(p => p.IdEstudioNavigation)
                .Include(p => p.IdProfesionNavigation)
                .Include(p => p.IdProyectoNavigation)
                .Include(p => p.IdTipoDocumentoNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesional == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // GET: Profesionals/Create
        public IActionResult Create()
        {
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "IdCargo");
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje");
            ViewData["IdEstudio"] = new SelectList(_context.Estudios, "IdEstudio", "IdEstudio");
            ViewData["IdProfesion"] = new SelectList(_context.Profesiones, "IdProfesion", "IdProfesion");
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto");
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento");
            return View();
        }

        // POST: Profesionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesional,Nombres,Apellidos,IdTipoDocumento,NoDocumento,Correo,Telefono,IdProfesion,IdEstudio,IdCargo,IdProyecto,IdEje")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "IdCargo", profesional.IdCargo);
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", profesional.IdEje);
            ViewData["IdEstudio"] = new SelectList(_context.Estudios, "IdEstudio", "IdEstudio", profesional.IdEstudio);
            ViewData["IdProfesion"] = new SelectList(_context.Profesiones, "IdProfesion", "IdProfesion", profesional.IdProfesion);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", profesional.IdProyecto);
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", profesional.IdTipoDocumento);
            return View(profesional);
        }

        // GET: Profesionals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesional.FindAsync(id);
            if (profesional == null)
            {
                return NotFound();
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "IdCargo", profesional.IdCargo);
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", profesional.IdEje);
            ViewData["IdEstudio"] = new SelectList(_context.Estudios, "IdEstudio", "IdEstudio", profesional.IdEstudio);
            ViewData["IdProfesion"] = new SelectList(_context.Profesiones, "IdProfesion", "IdProfesion", profesional.IdProfesion);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", profesional.IdProyecto);
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", profesional.IdTipoDocumento);
            return View(profesional);
        }

        // POST: Profesionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdProfesional,Nombres,Apellidos,IdTipoDocumento,NoDocumento,Correo,Telefono,IdProfesion,IdEstudio,IdCargo,IdProyecto,IdEje")] Profesional profesional)
        {
            if (id != profesional.IdProfesional)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalExists(profesional.IdProfesional))
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
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "IdCargo", profesional.IdCargo);
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", profesional.IdEje);
            ViewData["IdEstudio"] = new SelectList(_context.Estudios, "IdEstudio", "IdEstudio", profesional.IdEstudio);
            ViewData["IdProfesion"] = new SelectList(_context.Profesiones, "IdProfesion", "IdProfesion", profesional.IdProfesion);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", profesional.IdProyecto);
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", profesional.IdTipoDocumento);
            return View(profesional);
        }

        // GET: Profesionals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesional
                .Include(p => p.IdCargoNavigation)
                .Include(p => p.IdEjeNavigation)
                .Include(p => p.IdEstudioNavigation)
                .Include(p => p.IdProfesionNavigation)
                .Include(p => p.IdProyectoNavigation)
                .Include(p => p.IdTipoDocumentoNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesional == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // POST: Profesionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profesional = await _context.Profesional.FindAsync(id);
            _context.Profesional.Remove(profesional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionalExists(string id)
        {
            return _context.Profesional.Any(e => e.IdProfesional == id);
        }
    }
}
