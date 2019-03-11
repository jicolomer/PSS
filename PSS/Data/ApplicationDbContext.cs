using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PSS.Models;

namespace PSS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<PSS.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<PSS.Models.Empresa> Empresa { get; set; }

        public DbSet<PSS.Models.UsuarioEmpresa> UsuarioEmpresa { get; set; }

        public DbSet<PSS.Models.Proyectos> Proyectos { get; set; }

        public DbSet<PSS.Models.Provincias> Provincias { get; set; }

        public DbSet<PSS.Models.Fases> Fases { get; set; }

        public DbSet<PSS.Models.TiposObra> TiposObra { get; set; }

    }
}
