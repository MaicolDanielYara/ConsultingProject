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
    public class ProfesionController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public ProfesionController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Profesiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesiones.ToListAsync());
        }

        // GET: Profesiones/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesiones = await _context.Profesiones
                .FirstOrDefaultAsync(m => m.IdProfesion == id);
            if (profesiones == null)
            {
                return NotFound();
            }

            return View(profesiones);
        }

        // GET: Profesiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesion,Profesion")] Profesiones profesiones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesiones);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "La Profesión se ha creado correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View(profesiones);
        }

        // GET: Profesiones/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesiones = await _context.Profesiones.FindAsync(id);
            if (profesiones == null)
            {
                return NotFound();
            }
            return View(profesiones);
        }

        // POST: Profesiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdProfesion,Profesion")] Profesiones profesiones)
        {
            if (id != profesiones.IdProfesion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionesExists(profesiones.IdProfesion))
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
            return View(profesiones);
        }

        // GET: Profesiones/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesiones = await _context.Profesiones
                .FirstOrDefaultAsync(m => m.IdProfesion == id);
            if (profesiones == null)
            {
                return NotFound();
            }

            return View(profesiones);
        }

        // POST: Profesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profesiones = await _context.Profesiones.FindAsync(id);
            _context.Profesiones.Remove(profesiones);
            await _context.SaveChangesAsync();
            TempData["MensajeEliminar"] = "La Profesión se ha eliminado correctamente";
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionesExists(string id)
        {
            return _context.Profesiones.Any(e => e.IdProfesion == id);
        }
    }
}
