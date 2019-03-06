using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSS.Data;
using PSS.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace PSS.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        UsuarioRole _usuarioRole;

        public List<SelectListItem> usuarioRole;
        public List<SelectListItem> usuarioEmpresa;

        public UsuariosController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _usuarioRole = new UsuarioRole();
            usuarioRole = new List<SelectListItem>();

        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            //Declaro una variable ID inicializado vacia
            var ID = "";
            //Declaro un objeto list que depende la clase Usuario
            List<Usuario> usuario = new List<Usuario>();
            //Ahora obtengo todos los registros de la tabla donde almaceno los usuarios
            //y lo almaceno en el objeto
            var appUsuario = await _context.ApplicationUser.ToListAsync();
            //ahora con una estructura foreach vamos a recorrer
            //todos los valores del objeto appUsuario
            foreach (var Data in appUsuario)
            {
                ID = Data.Id;
                usuarioRole = await _usuarioRole.GetRole(_userManager,_roleManager,ID);
                List<SelectListItem> usuarioEmpresa = new List<SelectListItem>();
                UsuarioEmpresaController uec = new UsuarioEmpresaController(_context);
                EmpresasController ec = new EmpresasController(_context);
                UsuarioEmpresa ue = new UsuarioEmpresa();
                List<UsuarioEmpresa> _usuarioEmpresa = await uec.GetEmpresaByUser(ID);
                List<Empresa> empresa = await ec.GetEmpresaByID(_usuarioEmpresa[0].EmpresaId); 
                    usuario.Add(new Usuario() {
                    Id = Data.Id,
                    UserName = Data.UserName,
                    PhoneNumber = Data.PhoneNumber,
                    Email = Data.Email,
                    Role = usuarioRole[0].Text,
                    EmpresaId = _usuarioEmpresa[0].EmpresaId.ToString(),
                    Empresa = empresa[0].Nombre


                    });
            }
            return View(usuario.ToList());
            //return View(await _context.ApplicationUser.ToListAsync());
        }

        public async Task<List<Usuario>> GetUsuario (string id)
        {
            //Declaro un objeto list que depende la clase Usuario
            List<Usuario> usuario = new List<Usuario>();
            var appUsuario = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            usuarioRole = await _usuarioRole.GetRole(_userManager, _roleManager, id);
            UsuarioEmpresaController uec = new UsuarioEmpresaController(_context);
            EmpresasController ec = new EmpresasController(_context);
            //saco el idempresa
            List<UsuarioEmpresa> ue = await  uec.GetEmpresaByUser(appUsuario.Id);
            List<Empresa> empresa = await ec.GetEmpresaByID(ue[0].EmpresaId);

            usuario.Add(new Usuario() {
                Id = appUsuario.Id,
                UserName = appUsuario.UserName,
                PhoneNumber = appUsuario.PhoneNumber,
                Email = appUsuario.Email,
                Role = usuarioRole[0].Text,
                RoleId = usuarioRole[0].Value,
                AccessFailedCount = appUsuario.AccessFailedCount,
                ConcurrencyStamp = appUsuario.ConcurrencyStamp,
                EmailConfirmed = appUsuario.EmailConfirmed,
                LockoutEnabled = appUsuario.LockoutEnabled,
                LockoutEnd = appUsuario.LockoutEnd,
                NormalizedEmail = appUsuario.NormalizedEmail,
                NormalizedUserName = appUsuario.NormalizedUserName,
                PasswordHash = appUsuario.PasswordHash,
                PhoneNumberConfirmed = appUsuario.PhoneNumberConfirmed,
                SecurityStamp = appUsuario.SecurityStamp,
                TwoFactorEnabled = appUsuario.TwoFactorEnabled,
                Empresa = empresa[0].Nombre,
                EmpresaId = ue[0].EmpresaId.ToString()

            });
            return usuario;
        }
        public async Task<List<SelectListItem>> GetRoles()
        {
            //Creamos un objeto llamado rolesLista
            List<SelectListItem> rolesLista = new List<SelectListItem>();

            rolesLista = _usuarioRole.Roles(_roleManager);

            return rolesLista;

        }

        public async Task<string> EditUsuario(string id,string userName,string email,
           string phoneNumber, int accessFailedCount, string concurrencyStamp, bool emailConfirmed,
           bool lockoutEnabled, DateTimeOffset lockoutEnd, string normalizedEmail,
           string normalizedUserName, string passwordHash, bool phoneNumberConfirmed,
           string securityStamp, bool twoFactorEnabled,string selectRole, ApplicationUser applicationUser, 
           string selectEmpresa)
        {
            var resp = "";
            try
            {
                applicationUser = new ApplicationUser
                {
                    Id=id,
                    UserName=userName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    EmailConfirmed = emailConfirmed,
                    LockoutEnabled = lockoutEnabled,
                    LockoutEnd = lockoutEnd,
                    NormalizedEmail = normalizedEmail,
                    NormalizedUserName = normalizedUserName,
                    PasswordHash = passwordHash,
                    PhoneNumberConfirmed = phoneNumberConfirmed,
                    SecurityStamp = securityStamp,
                    TwoFactorEnabled = twoFactorEnabled,
                    AccessFailedCount = accessFailedCount,
                    ConcurrencyStamp = concurrencyStamp
                };
                //Actualizamos los datos
                _context.Update(applicationUser);
                await _context.SaveChangesAsync();

                //Obtenemos el usuario
                var usuario = await _userManager.FindByIdAsync(id);

                usuarioRole = await _usuarioRole.GetRole(_userManager, _roleManager, id);


                if (usuarioRole[0].Text != "No Role")
                {
                    await _userManager.RemoveFromRoleAsync(usuario, usuarioRole[0].Text);
                }

                if (selectRole == "No Role")
                {
                    selectRole = "No Role";
                }

                //Ahora si almacenamos el rol
                var resultado = await _userManager.AddToRoleAsync(usuario, selectRole);

                await _context.SaveChangesAsync();

                try
                {

                    UsuarioEmpresa ue = new UsuarioEmpresa();
                    ue.Id = applicationUser.Id;
                    ue.EmpresaId = int.Parse(selectEmpresa);

                    try
                    {
                        _context.UsuarioEmpresa.Add(ue);

                        await _context.SaveChangesAsync();

                    }
                    catch (Exception)
                    {

                        _context.UsuarioEmpresa.Update(ue);

                        await _context.SaveChangesAsync();
                    }


                }
                catch (Exception ex)
                {
                    resp = "NoSave";
                }


                resp = "Save";
            }
            catch (Exception ex2 )
            {
                resp = "No Save";

            }
            return resp;

        }



        public async Task<String> DeleteUsuario(string id)
        {
            var resp = "";
            try
            {

                var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
                _context.ApplicationUser.Remove(applicationUser);

                await _context.SaveChangesAsync();
                try
                {
                    UsuarioEmpresa ue = new UsuarioEmpresa();
                    ue.Id = id;
                    _context.UsuarioEmpresa.Remove(ue);
                    await _context.SaveChangesAsync();
                    resp = "Delete";
                }
                catch (Exception exxxc)
                {
                    if (exxxc.Message.Contains ("row")) resp = "Delete";
                    else resp = "NODelete";
                }



            }
            catch(Exception exx)
            {
                resp = "NoDelete";
            }
            return resp;
        }

        public async Task<String> CreateUsuario(string email,
            string phoneNumber, string passwordHash, 
            string selectRole, string selectEmpresa, ApplicationUser applicationUser)
        {
            var resp = "";
            applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                PhoneNumber = phoneNumber
            };
            var result = await _userManager.CreateAsync(applicationUser, passwordHash);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, selectRole);


                //añado la empresa
                UsuarioEmpresa ue = new UsuarioEmpresa();
                ue.Id = applicationUser.Id;
                ue.EmpresaId = int.Parse(selectEmpresa);
                UsuarioEmpresaController uec = new UsuarioEmpresaController(_context);
                try
                {
                    uec.Create(ue);
                }
                catch (Exception ex)
                {
                    resp = "NoSave";
                }

                resp = "Save";
            }
            else
            {
                resp = "NoSave";
            }
            return resp;

        }

        
        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
