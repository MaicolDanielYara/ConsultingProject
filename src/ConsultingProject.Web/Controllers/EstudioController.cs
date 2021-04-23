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
    public class EstudioController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public EstudioController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Estudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudios.ToListAsync());
        }

        // GET: Estudios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudios = await _context.Estudios
                .FirstOrDefaultAsync(m => m.IdEstudio == id);
            if (estudios == null)
            {
                return NotFound();
            }

            return View(estudios);
        }

        // GET: Estudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudio,Estudio")] Estudios estudios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudios);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El Estudio se ha creado correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View(estudios);
        }

        // GET: Estudios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudios = await _context.Estudios.FindAsync(id);
            if (estudios == null)
            {
                return NotFound();
            }
            return View(estudios);
        }

        // POST: Estudios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdEstudio,Estudio")] Estudios estudios)
        {
            if (id != estudios.IdEstudio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiosExists(estudios.IdEstudio))
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
            return View(estudios);
        }

        // GET: Estudios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudios = await _context.Estudios
                .FirstOrDefaultAsync(m => m.IdEstudio == id);
            if (estudios == null)
            {
                return NotFound();
            }

            return View(estudios);
        }

        // POST: Estudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var estudios = await _context.Estudios.FindAsync(id);
            _context.Estudios.Remove(estudios);
            await _context.SaveChangesAsync();
            TempData["MensajeEliminar"] = "El Estudio se ha eliminado correctamente";
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiosExists(string id)
        {
            return _context.Estudios.Any(e => e.IdEstudio == id);
        }
    }
}
