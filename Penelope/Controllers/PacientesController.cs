using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSS.Data;
using Penelope;
using Microsoft.AspNetCore.Http;
namespace Penelope.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index(int id)
        {
            var myPaciente = await _context.Pacientes.Where(c => c.Numerohc == id).ToListAsync();
            //ahora con una estructura foreach vamos a recorrer
            HttpContext.Session.Clear();
            foreach (var Data in myPaciente)
            {

                HttpContext.Session.SetString("nhc", Data.Numerohc.ToString());
                HttpContext.Session.SetString("nombre", Data.Nombre);
                HttpContext.Session.SetString("apellido1", Data.Apellid1);
                HttpContext.Session.SetString("apellido2", Data.Apellid2);
                HttpContext.Session.SetString("fnacimiento", Data.Fechanac.ToString().Substring(0,10));
                DateTime oldDate = DateTime.Parse(Data.Fechanac.ToString());
                DateTime newDate = DateTime.Today;
                int age = newDate.Year - oldDate.Year;
                HttpContext.Session.SetString("edad", age.ToString());
            }
            return View(await _context.Pacientes.Where(c => c.Numerohc == id).ToListAsync());
            //return View(await _context.Pacientes.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes
                .SingleOrDefaultAsync(m => m.Numerohc == id);
            if (pacientes == null)
            {
                return NotFound();
            }

            return View(pacientes);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numerohc,Nombre,Apellid1,Apellid2,Fechanac,Dni,Paisresi,Domicont,Poblares,Provresi,Codpost,Telefono,Telefono2,Numeross1,Numeross2,Numeross3,Sexo,Numtis,Raza,Provinac,Poblanac,Autonaci,Autoresi,Paisnaci,Estcivil,Telecont,Estadopa,Fecestad,Centap,Historiap,Cip,Telefonoap,Telreuma1,Telreuma1anot,Telreuma2,Telreuma2anot,Email,Anotaciones")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacientes);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes.SingleOrDefaultAsync(m => m.Numerohc == id);
            if (pacientes == null)
            {
                return NotFound();
            }
            return View(pacientes);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Numerohc,Nombre,Apellid1,Apellid2,Fechanac,Dni,Paisresi,Domicont,Poblares,Provresi,Codpost,Telefono,Telefono2,Numeross1,Numeross2,Numeross3,Sexo,Numtis,Raza,Provinac,Poblanac,Autonaci,Autoresi,Paisnaci,Estcivil,Telecont,Estadopa,Fecestad,Centap,Historiap,Cip,Telefonoap,Telreuma1,Telreuma1anot,Telreuma2,Telreuma2anot,Email,Anotaciones")] Pacientes pacientes)
        {
            if (id != pacientes.Numerohc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientesExists(pacientes.Numerohc))
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
            return View(pacientes);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes
                .SingleOrDefaultAsync(m => m.Numerohc == id);
            if (pacientes == null)
            {
                return NotFound();
            }

            return View(pacientes);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacientes = await _context.Pacientes.SingleOrDefaultAsync(m => m.Numerohc == id);
            _context.Pacientes.Remove(pacientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientesExists(int id)
        {
            return _context.Pacientes.Any(e => e.Numerohc == id);
        }


        [HttpPost]
        public JsonResult Buscar(string Prefix)
        {
            try
            {
                if (Prefix == null) return Json(new Exception("Vacía"));

                var lista = new List<Pacientes>();


                var pacientes = from e in _context.Pacientes.Where(
                    c => c.Nombre.Contains(Prefix) || 
                    c.Apellid1.Contains(Prefix) || 
                    c.Apellid2.Contains(Prefix) || 
                    c.Numerohc.ToString().Contains(Prefix) || 
                    c.Dni.ToString().Contains(Prefix))
                    .OrderBy(c=> c.Apellid1).ThenBy(c=>c.Apellid2).ThenBy(c=>c.Nombre)
                                select new
                             {
                                 nombre = e.Nombre,
                                 apellido1= e.Apellid1,
                                 apellido2 = e.Apellid2,
                                 numerohc= e.Numerohc,
                                 fechanac = e.Fechanac
                             };
                var rows = pacientes.ToArray();

                return Json(rows);

            }
            catch (Exception ex)
            {
            
                throw ex;
            }
        }
    }
}
