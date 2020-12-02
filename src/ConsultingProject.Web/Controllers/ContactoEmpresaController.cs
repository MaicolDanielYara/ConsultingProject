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
    public class ContactoEmpresaController : Controller
    {
        private readonly ConsultingProjectDbContext _context;

        public ContactoEmpresaController(ConsultingProjectDbContext context)
        {
            _context = context;
        }

        // GET: ContactoEmpresas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactoEmpresa.ToListAsync());
        }

        // GET: ContactoEmpresas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactoEmpresa = await _context.ContactoEmpresa
                .FirstOrDefaultAsync(m => m.IdContactoEmpresa == id);
            if (contactoEmpresa == null)
            {
                return NotFound();
            }

            return View(contactoEmpresa);
        }

        // GET: ContactoEmpresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactoEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContactoEmpresa,NombresContactoEmpresa,ApellidosContactoEmpresa,Correo,Telefono")] ContactoEmpresa contactoEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactoEmpresa);
        }

        // GET: ContactoEmpresas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactoEmpresa = await _context.ContactoEmpresa.FindAsync(id);
            if (contactoEmpresa == null)
            {
                return NotFound();
            }
            return View(contactoEmpresa);
        }

        // POST: ContactoEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdContactoEmpresa,NombresContactoEmpresa,ApellidosContactoEmpresa,Correo,Telefono")] ContactoEmpresa contactoEmpresa)
        {
            if (id != contactoEmpresa.IdContactoEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoEmpresaExists(contactoEmpresa.IdContactoEmpresa))
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
            return View(contactoEmpresa);
        }

        // GET: ContactoEmpresas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactoEmpresa = await _context.ContactoEmpresa
                .FirstOrDefaultAsync(m => m.IdContactoEmpresa == id);
            if (contactoEmpresa == null)
            {
                return NotFound();
            }

            return View(contactoEmpresa);
        }

        // POST: ContactoEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contactoEmpresa = await _context.ContactoEmpresa.FindAsync(id);
            _context.ContactoEmpresa.Remove(contactoEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoEmpresaExists(string id)
        {
            return _context.ContactoEmpresa.Any(e => e.IdContactoEmpresa == id);
        }
    }
}
