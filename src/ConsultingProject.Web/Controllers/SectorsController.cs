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
    public class SectorsController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public SectorsController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Sectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sector.ToListAsync());
        }

        // GET: Sectors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .FirstOrDefaultAsync(m => m.IdSector == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // GET: Sectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSector,Sector1")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sector);
        }

        // GET: Sectors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSector,Sector1")] Sector sector)
        {
            if (id != sector.IdSector)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorExists(sector.IdSector))
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
            return View(sector);
        }

        // GET: Sectors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .FirstOrDefaultAsync(m => m.IdSector == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sector = await _context.Sector.FindAsync(id);
            _context.Sector.Remove(sector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectorExists(string id)
        {
            return _context.Sector.Any(e => e.IdSector == id);
        }
    }
}
