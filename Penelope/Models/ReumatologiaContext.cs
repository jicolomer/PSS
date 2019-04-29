using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Penelope
{
    public partial class ReumatologiaContext : DbContext
    {
        public virtual DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=192.168.1.80;Database=Reumatologia;MultipleActiveResultSets=true;User Id=sa; Password=As.2008;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.Numerohc);

                entity.ToTable("pacientes");

                entity.Property(e => e.Numerohc)
                    .HasColumnName("numerohc")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anotaciones)
                    .HasColumnName("anotaciones")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Apellid1)
                    .HasColumnName("apellid1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Apellid2)
                    .HasColumnName("apellid2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Autonaci).HasColumnName("autonaci");

                entity.Property(e => e.Autoresi).HasColumnName("autoresi");

                entity.Property(e => e.Centap)
                    .HasColumnName("centap")
                    .HasColumnType("nchar(4)");

                entity.Property(e => e.Cip)
                    .HasColumnName("cip")
                    .HasColumnType("nchar(16)");

                entity.Property(e => e.Codpost).HasColumnName("codpost");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Domicont)
                    .HasColumnName("domicont")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estadopa)
                    .HasColumnName("estadopa")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Estcivil).HasColumnName("estcivil");

                entity.Property(e => e.Fecestad)
                    .HasColumnName("fecestad")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechanac)
                    .HasColumnName("fechanac")
                    .HasColumnType("datetime");

                entity.Property(e => e.Historiap).HasColumnName("historiap");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Numeross1).HasColumnName("numeross1");

                entity.Property(e => e.Numeross2).HasColumnName("numeross2");

                entity.Property(e => e.Numeross3).HasColumnName("numeross3");

                entity.Property(e => e.Numtis)
                    .HasColumnName("numtis")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Paisnaci).HasColumnName("paisnaci");

                entity.Property(e => e.Paisresi).HasColumnName("paisresi");

                entity.Property(e => e.Poblanac).HasColumnName("poblanac");

                entity.Property(e => e.Poblares).HasColumnName("poblares");

                entity.Property(e => e.Provinac).HasColumnName("provinac");

                entity.Property(e => e.Provresi).HasColumnName("provresi");

                entity.Property(e => e.Raza)
                    .HasColumnName("raza")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Telecont)
                    .HasColumnName("telecont")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono2)
                    .HasColumnName("telefono2")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Telefonoap)
                    .HasColumnName("telefonoap")
                    .HasColumnType("nchar(9)");

                entity.Property(e => e.Telreuma1)
                    .HasColumnName("telreuma1")
                    .HasColumnType("nchar(9)");

                entity.Property(e => e.Telreuma1anot)
                    .HasColumnName("telreuma1anot")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telreuma2)
                    .HasColumnName("telreuma2")
                    .HasColumnType("nchar(9)");

                entity.Property(e => e.Telreuma2anot)
                    .HasColumnName("telreuma2anot")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
