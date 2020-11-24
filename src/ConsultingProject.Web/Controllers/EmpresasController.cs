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
    public class EmpresasController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public EmpresasController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var consultingProjectDbContext = _context.Empresa.Include(e => e.CódigoDepartamentoNavigation).Include(e => e.CódigoMunicipioNavigation).Include(e => e.IdEjeNavigation).Include(e => e.IdProfesionalNavigation).Include(e => e.IdProyectoNavigation).Include(e => e.IdSectorNavigation).Include(e => e.IdTamañoEmpresaNavigation);
            return View(await consultingProjectDbContext.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .Include(e => e.CódigoDepartamentoNavigation)
                .Include(e => e.CódigoMunicipioNavigation)
                .Include(e => e.IdEjeNavigation)
                .Include(e => e.IdProfesionalNavigation)
                .Include(e => e.IdProyectoNavigation)
                .Include(e => e.IdSectorNavigation)
                .Include(e => e.IdTamañoEmpresaNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewData["CódigoDepartamento"] = new SelectList(_context.Departamento, "CódigoDepartamento", "CódigoDepartamento");
            ViewData["CódigoMunicipio"] = new SelectList(_context.Municipio, "CódigoMunicipio", "CódigoMunicipio");
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje");
            ViewData["IdProfesional"] = new SelectList(_context.Profesional, "IdProfesional", "IdProfesional");
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto");
            ViewData["IdSector"] = new SelectList(_context.Sector, "IdSector", "IdSector");
            ViewData["IdTamañoEmpresa"] = new SelectList(_context.TamañoEmpresa, "IdTamañoEmpresa", "IdTamañoEmpresa");
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresa,NombreEmpresa,Nit,DigitoVerificacion,Fechaconstlegal,CódigoDepartamento,CódigoMunicipio,IdSector,IdTamañoEmpresa,IdEje,IdProyecto,IdProfesional")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CódigoDepartamento"] = new SelectList(_context.Departamento, "CódigoDepartamento", "CódigoDepartamento", empresa.CódigoDepartamento);
            ViewData["CódigoMunicipio"] = new SelectList(_context.Municipio, "CódigoMunicipio", "CódigoMunicipio", empresa.CódigoMunicipio);
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", empresa.IdEje);
            ViewData["IdProfesional"] = new SelectList(_context.Profesional, "IdProfesional", "IdProfesional", empresa.IdProfesional);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", empresa.IdProyecto);
            ViewData["IdSector"] = new SelectList(_context.Sector, "IdSector", "IdSector", empresa.IdSector);
            ViewData["IdTamañoEmpresa"] = new SelectList(_context.TamañoEmpresa, "IdTamañoEmpresa", "IdTamañoEmpresa", empresa.IdTamañoEmpresa);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["CódigoDepartamento"] = new SelectList(_context.Departamento, "CódigoDepartamento", "CódigoDepartamento", empresa.CódigoDepartamento);
            ViewData["CódigoMunicipio"] = new SelectList(_context.Municipio, "CódigoMunicipio", "CódigoMunicipio", empresa.CódigoMunicipio);
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", empresa.IdEje);
            ViewData["IdProfesional"] = new SelectList(_context.Profesional, "IdProfesional", "IdProfesional", empresa.IdProfesional);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", empresa.IdProyecto);
            ViewData["IdSector"] = new SelectList(_context.Sector, "IdSector", "IdSector", empresa.IdSector);
            ViewData["IdTamañoEmpresa"] = new SelectList(_context.TamañoEmpresa, "IdTamañoEmpresa", "IdTamañoEmpresa", empresa.IdTamañoEmpresa);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpresa,NombreEmpresa,Nit,DigitoVerificacion,Fechaconstlegal,CódigoDepartamento,CódigoMunicipio,IdSector,IdTamañoEmpresa,IdEje,IdProyecto,IdProfesional")] Empresa empresa)
        {
            if (id != empresa.IdEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.IdEmpresa))
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
            ViewData["CódigoDepartamento"] = new SelectList(_context.Departamento, "CódigoDepartamento", "CódigoDepartamento", empresa.CódigoDepartamento);
            ViewData["CódigoMunicipio"] = new SelectList(_context.Municipio, "CódigoMunicipio", "CódigoMunicipio", empresa.CódigoMunicipio);
            ViewData["IdEje"] = new SelectList(_context.EjeSeleccionado, "IdEje", "IdEje", empresa.IdEje);
            ViewData["IdProfesional"] = new SelectList(_context.Profesional, "IdProfesional", "IdProfesional", empresa.IdProfesional);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "IdProyecto", empresa.IdProyecto);
            ViewData["IdSector"] = new SelectList(_context.Sector, "IdSector", "IdSector", empresa.IdSector);
            ViewData["IdTamañoEmpresa"] = new SelectList(_context.TamañoEmpresa, "IdTamañoEmpresa", "IdTamañoEmpresa", empresa.IdTamañoEmpresa);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .Include(e => e.CódigoDepartamentoNavigation)
                .Include(e => e.CódigoMunicipioNavigation)
                .Include(e => e.IdEjeNavigation)
                .Include(e => e.IdProfesionalNavigation)
                .Include(e => e.IdProyectoNavigation)
                .Include(e => e.IdSectorNavigation)
                .Include(e => e.IdTamañoEmpresaNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.IdEmpresa == id);
        }
    }
}
