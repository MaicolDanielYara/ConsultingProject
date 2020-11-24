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
    public class TamañoEmpresaController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public TamañoEmpresaController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: TamañoEmpresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.TamañoEmpresa.ToListAsync());
        }

        // GET: TamañoEmpresa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tamañoEmpresa = await _context.TamañoEmpresa
                .FirstOrDefaultAsync(m => m.IdTamañoEmpresa == id);
            if (tamañoEmpresa == null)
            {
                return NotFound();
            }

            return View(tamañoEmpresa);
        }

        // GET: TamañoEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TamañoEmpresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTamañoEmpresa,TamañoEmpresa1")] TamañoEmpresa tamañoEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tamañoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tamañoEmpresa);
        }

        // GET: TamañoEmpresa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tamañoEmpresa = await _context.TamañoEmpresa.FindAsync(id);
            if (tamañoEmpresa == null)
            {
                return NotFound();
            }
            return View(tamañoEmpresa);
        }

        // POST: TamañoEmpresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdTamañoEmpresa,TamañoEmpresa1")] TamañoEmpresa tamañoEmpresa)
        {
            if (id != tamañoEmpresa.IdTamañoEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tamañoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TamañoEmpresaExists(tamañoEmpresa.IdTamañoEmpresa))
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
            return View(tamañoEmpresa);
        }

        // GET: TamañoEmpresa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tamañoEmpresa = await _context.TamañoEmpresa
                .FirstOrDefaultAsync(m => m.IdTamañoEmpresa == id);
            if (tamañoEmpresa == null)
            {
                return NotFound();
            }

            return View(tamañoEmpresa);
        }

        // POST: TamañoEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tamañoEmpresa = await _context.TamañoEmpresa.FindAsync(id);
            _context.TamañoEmpresa.Remove(tamañoEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TamañoEmpresaExists(string id)
        {
            return _context.TamañoEmpresa.Any(e => e.IdTamañoEmpresa == id);
        }
    }
}
