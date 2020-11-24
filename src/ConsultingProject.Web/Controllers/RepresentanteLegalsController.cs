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
    public class RepresentanteLegalsController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public RepresentanteLegalsController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: RepresentanteLegals
        public async Task<IActionResult> Index()
        {
            var consultingProjectDbContext = _context.RepresentanteLegal.Include(r => r.IdEmpresaNavigation).Include(r => r.IdTipoDocumentoNavigation);
            return View(await consultingProjectDbContext.ToListAsync());
        }

        // GET: RepresentanteLegals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteLegal = await _context.RepresentanteLegal
                .Include(r => r.IdEmpresaNavigation)
                .Include(r => r.IdTipoDocumentoNavigation)
                .FirstOrDefaultAsync(m => m.IdReprLegal == id);
            if (representanteLegal == null)
            {
                return NotFound();
            }

            return View(representanteLegal);
        }

        // GET: RepresentanteLegals/Create
        public IActionResult Create()
        {
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEje");
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento");
            return View();
        }

        // POST: RepresentanteLegals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReprLegal,NombresRepresentanteLegal,ApellidosRepresentanteLegal,IdTipoDocumento,NoDocumento,Correo,Telefono,IdEmpresa")] RepresentanteLegal representanteLegal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(representanteLegal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEje", representanteLegal.IdEmpresa);
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", representanteLegal.IdTipoDocumento);
            return View(representanteLegal);
        }

        // GET: RepresentanteLegals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteLegal = await _context.RepresentanteLegal.FindAsync(id);
            if (representanteLegal == null)
            {
                return NotFound();
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEje", representanteLegal.IdEmpresa);
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", representanteLegal.IdTipoDocumento);
            return View(representanteLegal);
        }

        // POST: RepresentanteLegals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdReprLegal,NombresRepresentanteLegal,ApellidosRepresentanteLegal,IdTipoDocumento,NoDocumento,Correo,Telefono,IdEmpresa")] RepresentanteLegal representanteLegal)
        {
            if (id != representanteLegal.IdReprLegal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(representanteLegal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepresentanteLegalExists(representanteLegal.IdReprLegal))
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
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "IdEmpresa", "IdEje", representanteLegal.IdEmpresa);
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", representanteLegal.IdTipoDocumento);
            return View(representanteLegal);
        }

        // GET: RepresentanteLegals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteLegal = await _context.RepresentanteLegal
                .Include(r => r.IdEmpresaNavigation)
                .Include(r => r.IdTipoDocumentoNavigation)
                .FirstOrDefaultAsync(m => m.IdReprLegal == id);
            if (representanteLegal == null)
            {
                return NotFound();
            }

            return View(representanteLegal);
        }

        // POST: RepresentanteLegals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var representanteLegal = await _context.RepresentanteLegal.FindAsync(id);
            _context.RepresentanteLegal.Remove(representanteLegal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepresentanteLegalExists(string id)
        {
            return _context.RepresentanteLegal.Any(e => e.IdReprLegal == id);
        }
    }
}
