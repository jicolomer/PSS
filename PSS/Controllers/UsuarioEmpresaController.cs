using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSS.Data;
using PSS.Models;

namespace PSS.Controllers
{
    public class UsuarioEmpresaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioEmpresaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsuarioEmpresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioEmpresa.ToListAsync());
        }

        // GET: UsuarioEmpresa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEmpresa = await _context.UsuarioEmpresa
                .SingleOrDefaultAsync(m => m.Id == id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioEmpresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpresaId")] UsuarioEmpresa usuarioEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEmpresa = await _context.UsuarioEmpresa.SingleOrDefaultAsync(m => m.Id == id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }
            return View(usuarioEmpresa);
        }

        // POST: UsuarioEmpresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,EmpresaId")] UsuarioEmpresa usuarioEmpresa)
        {
            if (id != usuarioEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioEmpresaExists(usuarioEmpresa.Id))
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
            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEmpresa = await _context.UsuarioEmpresa
                .SingleOrDefaultAsync(m => m.Id == id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            return View(usuarioEmpresa);
        }

        // POST: UsuarioEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuarioEmpresa = await _context.UsuarioEmpresa.SingleOrDefaultAsync(m => m.Id == id);
            _context.UsuarioEmpresa.Remove(usuarioEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioEmpresaExists(string id)
        {
            return _context.UsuarioEmpresa.Any(e => e.Id == id);
        }

        public async Task<List<UsuarioEmpresa>> GetEmpresaByUser(string id)
        {
            List<UsuarioEmpresa> empresa = new List<UsuarioEmpresa>();
            try
            {

                var appUsuarioEmpresa = await _context.UsuarioEmpresa.SingleOrDefaultAsync(m => m.Id == id);

                empresa.Add(new UsuarioEmpresa()
                {
                    Id = appUsuarioEmpresa.Id,
                    EmpresaId = appUsuarioEmpresa.EmpresaId
                });
                return empresa;
            }
            catch (Exception ex)
            {
                empresa.Add(new UsuarioEmpresa()
                {
                    Id = id,
                    EmpresaId = 0
                });
                return empresa;
            }

        }

    }
}
