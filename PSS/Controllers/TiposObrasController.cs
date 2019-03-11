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
    public class TiposObrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposObrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposObras
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposObra.ToListAsync());
        }

        // GET: TiposObras/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposObra = await _context.TiposObra
                .SingleOrDefaultAsync(m => m.IdTipoObra == id);
            if (tiposObra == null)
            {
                return NotFound();
            }

            return View(tiposObra);
        }

        // GET: TiposObras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposObras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoObra,TipoObra")] TiposObra tiposObra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposObra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposObra);
        }

        // GET: TiposObras/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposObra = await _context.TiposObra.SingleOrDefaultAsync(m => m.IdTipoObra == id);
            if (tiposObra == null)
            {
                return NotFound();
            }
            return View(tiposObra);
        }

        // POST: TiposObras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdTipoObra,TipoObra")] TiposObra tiposObra)
        {
            if (id != tiposObra.IdTipoObra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposObra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposObraExists(tiposObra.IdTipoObra))
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
            return View(tiposObra);
        }

        // GET: TiposObras/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposObra = await _context.TiposObra
                .SingleOrDefaultAsync(m => m.IdTipoObra == id);
            if (tiposObra == null)
            {
                return NotFound();
            }

            return View(tiposObra);
        }

        // POST: TiposObras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tiposObra = await _context.TiposObra.SingleOrDefaultAsync(m => m.IdTipoObra == id);
            _context.TiposObra.Remove(tiposObra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposObraExists(string id)
        {
            return _context.TiposObra.Any(e => e.IdTipoObra == id);
        }
    }
}
