using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSS.Models;
using Microsoft.AspNetCore.Authorization;
using PSS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace PSS.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        UsuarioRole _usuarioRole;
        public List<SelectListItem> usuarioRole;
        public List<SelectListItem> usuarioEmpresa;

        public HomeController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _usuarioRole = new UsuarioRole();
            usuarioRole = new List<SelectListItem>();
        }


        public IActionResult Index()
        {

            if (User.Identity.Name != null && HttpContext.Session.GetString("IdEmpresa")==null)
            {
                //Obtengo la empresa y la meto en el Session

                String nombreUsuario = User.Identity.Name;
                var appUsuario = _context.ApplicationUser.SingleOrDefault(m => m.UserName == nombreUsuario);
                var appUsuarioEmpresa = _context.UsuarioEmpresa.SingleOrDefault(m => m.Id == appUsuario.Id);
                var rol = _context.UserRoles.Where(m => m.UserId == appUsuario.Id);
                String IdRol = "";
                foreach (var Data in rol)
                {
                    IdRol = Data.RoleId;
                }
                var roles = _context.Roles.Where(m => m.Id== IdRol );
                String Rol = "";
                foreach (var Data in roles)
                {
                    Rol = Data.Name;
                }

                try
                {

                    var nombreEmpresa = _context.Empresa.SingleOrDefault(m => m.EmpresaId == appUsuarioEmpresa.EmpresaId);
                    HttpContext.Session.SetString("Empresa", nombreEmpresa.Nombre);
                    HttpContext.Session.SetString("IdEmpresa", nombreEmpresa.EmpresaId.ToString());
                    HttpContext.Session.SetString("Role",Rol);
                    HttpContext.Session.SetString("IdRole", IdRol);

                    ViewData["Nombre"] = "Empresa: " + nombreEmpresa.Nombre;
                }
                catch (Exception)
                {
                }
            }
            return View();
        }

        //[Authorize(Roles = "Administrador")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
