using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PSS.Models
{
    public partial class PSSContext_old : DbContext
    {
        public PSSContext_old()
        {
        }

        public PSSContext_old(DbContextOptions<PSSContext_old> options)
            : base(options)
        {
        }

        public virtual DbSet<Proyectos> Proyectos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PSS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Proyectos>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.Property(e => e.IdEmpresa).ValueGeneratedNever();

                entity.Property(e => e.Autor).HasMaxLength(255);

                entity.Property(e => e.AutorProyecto).HasMaxLength(255);

                entity.Property(e => e.CiudadContratista).HasMaxLength(255);

                entity.Property(e => e.CiudadObra).HasMaxLength(255);

                entity.Property(e => e.Cliente).HasMaxLength(255);

                entity.Property(e => e.Contratista).HasMaxLength(255);

                entity.Property(e => e.CpContratista).HasMaxLength(5);

                entity.Property(e => e.CpObra).HasMaxLength(50);

                entity.Property(e => e.CssfaseProyecto)
                    .HasColumnName("CSSFaseProyecto")
                    .HasMaxLength(255);

                entity.Property(e => e.DireccionContratista).HasMaxLength(255);

                entity.Property(e => e.DireccionObra).HasMaxLength(255);

                entity.Property(e => e.Encargado).HasMaxLength(255);

                entity.Property(e => e.IdObra).ValueGeneratedOnAdd();

                entity.Property(e => e.JefeObra).HasMaxLength(255);

                entity.Property(e => e.LinderoEste).HasMaxLength(255);

                entity.Property(e => e.LinderoNorte).HasMaxLength(255);

                entity.Property(e => e.LinderoOeste).HasMaxLength(255);

                entity.Property(e => e.LinderoSur).HasMaxLength(255);

                entity.Property(e => e.NombreObra).HasMaxLength(255);

                entity.Property(e => e.NumOt).HasMaxLength(50);

                entity.Property(e => e.PemPec)
                    .HasColumnName("PEM_PEC")
                    .HasMaxLength(50);

                entity.Property(e => e.Presupuesto).HasColumnType("money");

                entity.Property(e => e.Promotor).HasMaxLength(255);

                entity.Property(e => e.ProvinciaContratista).HasMaxLength(255);

                entity.Property(e => e.ProvinciaObra).HasMaxLength(255);

                entity.Property(e => e.RecursoPreventivo).HasMaxLength(255);

                entity.Property(e => e.Superficie).HasMaxLength(50);

                entity.Property(e => e.Tecnico).HasMaxLength(255);

                entity.Property(e => e.TipoEstudio).HasMaxLength(50);

                entity.Property(e => e.TipoObra).HasMaxLength(255);
            });
        }
    }
}
