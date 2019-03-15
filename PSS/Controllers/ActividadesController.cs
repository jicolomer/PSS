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
    public class ActividadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActividadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Actividades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actividades.ToListAsync());
        }

        // GET: Actividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades
                .SingleOrDefaultAsync(m => m.Id == id);
            if (actividades == null)
            {
                return NotFound();
            }

            return View(actividades);
        }

        // GET: Actividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdFase,IdActividad,Actividad,Descripcion")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actividades);
        }

        // GET: Actividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades.SingleOrDefaultAsync(m => m.Id == id);
            if (actividades == null)
            {
                return NotFound();
            }
            return View(actividades);
        }

        // POST: Actividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFase,IdActividad,Actividad,Descripcion")] Actividades actividades)
        {
            if (id != actividades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadesExists(actividades.Id))
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
            return View(actividades);
        }

        // GET: Actividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades
                .SingleOrDefaultAsync(m => m.Id == id);
            if (actividades == null)
            {
                return NotFound();
            }

            return View(actividades);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividades = await _context.Actividades.SingleOrDefaultAsync(m => m.Id == id);
            _context.Actividades.Remove(actividades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadesExists(int id)
        {
            return _context.Actividades.Any(e => e.Id == id);
        }




        public async Task<List<Actividades>> getActividadesPorFase(string ID)
        {

            List<Actividades> lista = new List<Actividades>();
            try
            {
                //Declaro un objeto list que depende la clase Usuario
                var obj = await _context.Actividades.SingleOrDefaultAsync(m => m.IdFase == int.Parse(ID));

                lista.Add(new Actividades()
                {
                    Id = obj.Id,
                    IdActividad = obj.IdActividad,
                    Actividad = obj.Actividad,
                    Descripcion = obj.Descripcion
                });

            }
            catch (Exception ex)
            {
                String a = ex.Message;
            }
            return lista;
        }

        
        public async Task<List<Actividades>> GetActividad(string id)
        {

            List<Actividades> lista = new List<Actividades>();
            try
            {
                //Declaro un objeto list que depende la clase Usuario
                var obj = await _context.Actividades.SingleOrDefaultAsync(m => m.Id == int.Parse(id));

                lista.Add(new Actividades()
                {
                    Id = obj.Id,
                    IdActividad = obj.IdActividad,
                    Actividad = obj.Actividad,
                    Descripcion = obj.Descripcion
                });

            }
            catch (Exception ex)
            {
                String a = ex.Message;
            }
            return lista;
        }

        public async Task<string> ActualizarActividadPorProyecto(String Id, String IdActividad, String Actividad, String Descripcion)
        {
            var resp = "";
            try
            {

                Actividades myActividad = new Actividades
                {
                    Id = int.Parse(Id),
                    IdActividad = IdActividad,
                    Actividad = Actividad,
                    Descripcion = Descripcion

                };
                //Actualizamos los datos
                _context.Update(Actividad);
                await _context.SaveChangesAsync();

                resp = "OK";
            }
            catch (Exception ex2)
            {
                resp = ex2.Message;

            }
            return resp;

        }

        public async Task<string> CrearActividadPorProyecto(String IdFase, String IdActividad, String Actividad, String Descripcion)
        {
            string resp = "OK";
            try
            {
                Actividades myActividad = new Actividades();
                myActividad.IdFase = int.Parse(IdFase);
                myActividad.IdActividad = IdActividad;
                myActividad.Actividad = Actividad;
                myActividad.Descripcion = Descripcion;
                if (ModelState.IsValid)
                {
                    _context.Actividades.Add(myActividad);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    resp = "Error: Modelo inválido.";

                }
            }
            catch (Exception ex)
            {
                resp = "Error: " + ex.Message;
            }


            return resp;
        }


    }
}
