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
    public class FasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fases.ToListAsync());
        }

        // GET: Fases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fases = await _context.Fases
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fases == null)
            {
                return NotFound();
            }

            return View(fases);
        }

        // GET: Fases/Create
        public IActionResult Create()
        {
            return View();
        }


        public async Task<string> CrearFasePorProyecto(String IdProyecto, String IdFase, String Fase)
        {
            string resp = "OK";
            try
            {
                Fases fase = new Fases();
                fase.IdFase = IdFase;
                fase.IdProyecto = int.Parse(IdProyecto);
                fase.Fase = Fase;
                if (ModelState.IsValid)
                {
                    _context.Fases.Add(fase);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resp = "Error: Modelo inválido." ;

                }
            }
            catch (Exception ex)
            {
                resp = "Error: " + ex.Message; 
            }


            return resp;
        }

        // GET: Fases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fases = await _context.Fases.SingleOrDefaultAsync(m => m.Id == id);
            if (fases == null)
            {
                return NotFound();
            }
            return View(fases);
        }

        // POST: Fases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProyecto,IdFase,Fase")] Fases fases)
        {
            if (id != fases.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FasesExists(fases.Id))
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
            return View(fases);
        }

        // GET: Fases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fases = await _context.Fases
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fases == null)
            {
                return NotFound();
            }

            return View(fases);
        }

        // POST: Fases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fases = await _context.Fases.SingleOrDefaultAsync(m => m.Id == id);
            _context.Fases.Remove(fases);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FasesExists(int id)
        {
            return _context.Fases.Any(e => e.Id == id);
        }
    }
}
