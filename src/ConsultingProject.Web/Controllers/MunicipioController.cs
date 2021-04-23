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
    public class MunicipioController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public MunicipioController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: Municipios
        public async Task<IActionResult> Index()
        {
            var consultingProjectDbContext = _context.Municipio.Include(m => m.CódigoDepartamentoNavigation);
            return View(await consultingProjectDbContext.ToListAsync());
        }

        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio
                .Include(m => m.CódigoDepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.CódigoMunicipio == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        public IActionResult Create()
        {
            ViewData["CódigoDepartamento"] = new SelectList(_context.Departamento, "CódigoDepartamento", "CódigoDepartamento");
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CódigoMunicipio,NombreMunicipio,CódigoDepartamento")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipio);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El Municipio se ha agregado correctamente";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CódigoDepartamento"] = new SelectList(_context.Departamento, "CódigoDepartamento", "CódigoDepartamento", municipio.CódigoDepartamento);
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio.FindAsync(id);
            if (municipio == null)
            {
                return NotFound();
            }
            ViewData["CódigoDepartamento"] = new SelectList(_context.Departamento, "CódigoDepartamento", "CódigoDepartamento", municipio.CódigoDepartamento);
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CódigoMunicipio,NombreMunicipio,CódigoDepartamento")] Municipio municipio)
        {
            if (id != municipio.CódigoMunicipio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioExists(municipio.CódigoMunicipio))
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
            ViewData["CódigoDepartamento"] = new SelectList(_context.Departamento, "CódigoDepartamento", "CódigoDepartamento", municipio.CódigoDepartamento);
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio
                .Include(m => m.CódigoDepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.CódigoMunicipio == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipio = await _context.Municipio.FindAsync(id);
            _context.Municipio.Remove(municipio);
            await _context.SaveChangesAsync();
            TempData["MensajeEliminar"] = "El Municipio se ha eliminado correctamente";
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipioExists(int id)
        {
            return _context.Municipio.Any(e => e.CódigoMunicipio == id);
        }
    }
}
