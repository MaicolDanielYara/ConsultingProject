using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsultingProject.Web
{
    public partial class ConsultingProjectDbContext : DbContext
    {
        public ConsultingProjectDbContext()
        {
        }

        public ConsultingProjectDbContext(DbContextOptions<ConsultingProjectDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<EjeSeleccionado> EjeSeleccionado { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<NivelEstudios> NivelEstudios { get; set; }
        public virtual DbSet<Profesiones> Profesiones { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<RepresentanteLegal> RepresentanteLegal { get; set; }
        public virtual DbSet<TamañoEmpresa> TamañoEmpresa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("database=ConsultingProject;server=localhost;port=3310;user id=root;password=1000217042maicol");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PRIMARY");

                entity.ToTable("cargos");

                entity.Property(e => e.IdCargo)
                    .HasColumnName("Id_cargo")
                    .HasMaxLength(2);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<EjeSeleccionado>(entity =>
            {
                entity.HasKey(e => e.IdEje)
                    .HasName("PRIMARY");

                entity.ToTable("eje_seleccionado");

                entity.Property(e => e.IdEje)
                    .HasColumnName("Id_eje")
                    .HasMaxLength(4);

                entity.Property(e => e.Eje)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.HasIndex(e => e.IdEje)
                    .HasName("Id_eje");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("Id_proyecto");

                entity.HasIndex(e => e.IdTamañoEmpresa)
                    .HasName("Id_Tamaño_empresa");

                entity.HasIndex(e => e.NoDocumentoRl)
                    .HasName("No_documento_RL")
                    .IsUnique();

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("Id_empresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DigitoVerificacion)
                    .HasColumnName("Digito_verificacion")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fechaconstlegal)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEje)
                    .IsRequired()
                    .HasColumnName("Id_eje")
                    .HasMaxLength(4);

                entity.Property(e => e.IdProyecto)
                    .IsRequired()
                    .HasColumnName("Id_proyecto")
                    .HasMaxLength(6);

                entity.Property(e => e.IdTamañoEmpresa)
                    .IsRequired()
                    .HasColumnName("Id_Tamaño_empresa")
                    .HasMaxLength(6);

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NoDocumentoRl)
                    .HasColumnName("No_documento_RL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreEmpresa)
                    .HasColumnName("Nombre_empresa")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sector)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEjeNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdEje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_2");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_4");

                entity.HasOne(d => d.IdTamañoEmpresaNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdTamañoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_1");

                entity.HasOne(d => d.NoDocumentoRlNavigation)
                    .WithOne(p => p.Empresa)
                    .HasForeignKey<Empresa>(d => d.NoDocumentoRl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_3");
            });

            modelBuilder.Entity<NivelEstudios>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("nivel_estudios");

                entity.Property(e => e.IdNivelEstudio)
                    .IsRequired()
                    .HasColumnName("Id_Nivel_estudio")
                    .HasMaxLength(4);

                entity.Property(e => e.NivelEstudio)
                    .HasColumnName("Nivel_Estudio")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Profesiones>(entity =>
            {
                entity.HasKey(e => e.IdProfesion)
                    .HasName("PRIMARY");

                entity.ToTable("profesiones");

                entity.Property(e => e.IdProfesion)
                    .HasColumnName("Id_Profesion")
                    .HasMaxLength(4);

                entity.Property(e => e.Profesion)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PRIMARY");

                entity.ToTable("proyecto");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("Id_proyecto")
                    .HasMaxLength(6);

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_inicio")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NoConvenio)
                    .HasColumnName("No_Convenio")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreProyecto)
                    .HasColumnName("Nombre_proyecto")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Objeto).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PlazoEjecucion)
                    .HasColumnName("Plazo_Ejecucion")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Presupuesto)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<RepresentanteLegal>(entity =>
            {
                entity.HasKey(e => e.NoDocumentoRl)
                    .HasName("PRIMARY");

                entity.ToTable("representante_legal");

                entity.HasIndex(e => e.NoDocumentoRl)
                    .HasName("No_documento_RL")
                    .IsUnique();

                entity.Property(e => e.NoDocumentoRl)
                    .HasColumnName("No_documento_RL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApellidosRepresentanteLegal)
                    .HasColumnName("Apellidos_Representante_Legal")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombresRepresentanteLegal)
                    .HasColumnName("Nombres_Representante_Legal")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("Tipo_documento")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TamañoEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdTamañoEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("tamaño_empresa");

                entity.Property(e => e.IdTamañoEmpresa)
                    .HasColumnName("Id_Tamaño_empresa")
                    .HasMaxLength(6);

                entity.Property(e => e.TamañoEmpresa1)
                    .HasColumnName("Tamaño_empresa")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
