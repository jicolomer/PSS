using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSS.Data;
using PSS.Models;
using Microsoft.AspNetCore.Http;

namespace PSS.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProyectosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index()
        {
            String RolLogeado = HttpContext.Session.GetString("Role");
            String IdEmpre = HttpContext.Session.GetString("IdEmpresa");

            if (RolLogeado != "Administrador")
            {
                var retorno = await _context.Proyectos.Where(m => m.IdEmpre == int.Parse(IdEmpre)).ToListAsync();
                foreach (var Data in retorno)
                {
                    var nombreEmpresa = _context.Empresa.SingleOrDefault(m => m.EmpresaId == Data.IdEmpre);
                    Data.Empresa = nombreEmpresa.Nombre;
                }
                return View(retorno);

            }


            else
            {
                var retorno = await _context.Proyectos.ToListAsync();
                foreach (var Data in retorno)
                {
                    var nombreEmpresa = _context.Empresa.SingleOrDefault(m => m.EmpresaId == Data.IdEmpre);
                    Data.Empresa = nombreEmpresa.Nombre;

                }
                return View(retorno);

            }
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyectos = await _context.Proyectos
                .SingleOrDefaultAsync(m => m.IdObra == id);
            if (proyectos == null)
            {
                return NotFound();
            }

            return View(proyectos);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            ViewData["Empresa"] = HttpContext.Session.GetString("Empresa");
            ViewData["IdEmpresa"] = HttpContext.Session.GetString("IdEmpresa");
            return View();
        }

        // POST: Proyectos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObra,IdEmpre,NombreObra,NumOt,Cliente,DireccionObra,CiudadObra,ProvinciaObra,CpObra,Promotor,AutorProyecto,Tecnico,PemPec,Presupuesto,Duracion,Autor,CssfaseProyecto,NumTrabajadores,Contratista,DireccionContratista,CiudadContratista,ProvinciaContratista,CpContratista,JefeObra,Encargado,RecursoPreventivo,TipoObra,DescripcionObra,DescripcionLugar,Superficie,LinderoNorte,LinderoSur,LinderoEste,LinderoOeste,TraficoRodado,Climatologia,CaracteristicasTerreno,AccesosRodados,CirculacionesPeatonales,LinElectAereas,LinElectEnterradas,Transformadores,LineasTelefonicas,ConduccionesGas,Alcantarillado,InstProviAreasAux,TipoEstudio")] Proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyectos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyectos);
        }

        // GET: Proyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyectos = await _context.Proyectos.SingleOrDefaultAsync(m => m.IdObra == id);
            if (proyectos == null)
            {
                return NotFound();
            }
            return View(proyectos);
        }

        // POST: Proyectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObra,IdEmpre,NombreObra,NumOt,Cliente,DireccionObra,CiudadObra,ProvinciaObra,CpObra,Promotor,AutorProyecto,Tecnico,PemPec,Presupuesto,Duracion,Autor,CssfaseProyecto,NumTrabajadores,Contratista,DireccionContratista,CiudadContratista,ProvinciaContratista,CpContratista,JefeObra,Encargado,RecursoPreventivo,TipoObra,DescripcionObra,DescripcionLugar,Superficie,LinderoNorte,LinderoSur,LinderoEste,LinderoOeste,TraficoRodado,Climatologia,CaracteristicasTerreno,AccesosRodados,CirculacionesPeatonales,LinElectAereas,LinElectEnterradas,Transformadores,LineasTelefonicas,ConduccionesGas,Alcantarillado,InstProviAreasAux,TipoEstudio")] Proyectos proyectos)
        {
            if (id != proyectos.IdObra)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyectos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectosExists(proyectos.IdObra))
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
            return View(proyectos);
        }

        // GET: Proyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyectos = await _context.Proyectos
                .SingleOrDefaultAsync(m => m.IdObra == id);
            if (proyectos == null)
            {
                return NotFound();
            }

            return View(proyectos);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyectos = await _context.Proyectos.SingleOrDefaultAsync(m => m.IdObra == id);
            _context.Proyectos.Remove(proyectos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectosExists(int id)
        {
            return _context.Proyectos.Any(e => e.IdObra == id);
        }

        public async Task<List<SelectListItem>> GetTiposEstudio()
        {
            //Creamos un objeto llamado rolesLista
            List<SelectListItem> TELista = new List<SelectListItem>();
            SelectListItem li = new SelectListItem();
            li.Text = "PSS";
            li.Value = "PSS";
            TELista.Add(li);
            li = new SelectListItem();
            li.Text = "ESS";
            li.Value = "ESS";
            TELista.Add(li);
            li = new SelectListItem();
            li.Text = "EBSS";
            li.Value = "EBSS";
            TELista.Add(li);
            return TELista;

        }
    }

}

