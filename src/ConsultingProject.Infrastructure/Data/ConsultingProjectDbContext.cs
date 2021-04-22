using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConsultingProject.Core.Domain;

namespace ConsultingProject.Infrastructure.Data
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

        public virtual DbSet<Actividades> Actividades { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<ContactoEmpresa> ContactoEmpresa { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<EjeSeleccionado> EjeSeleccionado { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Etapas> Etapas { get; set; }
        public virtual DbSet<Herramientas> Herramientas { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Profesional> Profesional { get; set; }
        public virtual DbSet<Profesiones> Profesiones { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<RepresentanteLegal> RepresentanteLegal { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<TamañoEmpresa> TamañoEmpresa { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Cita> CitadeConsultoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("database=ConsultingProject;server=localhost;port=3310;user id=root;password=mysqlserver");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividades>(entity =>
            {
                entity.HasKey(e => e.IdActividad)
                    .HasName("PRIMARY");

                entity.ToTable("actividades");

                entity.HasIndex(e => e.IdEtapa)
                    .HasName("Id_etapa");

                entity.HasIndex(e => e.IdProfesional)
                    .HasName("Id_profesional");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("Id_proyecto");

                entity.Property(e => e.IdActividad)
                    .HasColumnName("Id_actividad")
                    .HasMaxLength(6);

                entity.Property(e => e.DescripcionActividad)
                    .HasColumnName("Descripcion_actividad")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEtapa)
                    .IsRequired()
                    .HasColumnName("Id_etapa")
                    .HasMaxLength(4);

                entity.Property(e => e.IdProfesional)
                    .IsRequired()
                    .HasColumnName("Id_profesional")
                    .HasMaxLength(4);

                entity.Property(e => e.IdProyecto)
                    .IsRequired()
                    .HasColumnName("Id_proyecto")
                    .HasMaxLength(6);

                entity.Property(e => e.NombreActividad)
                    .HasColumnName("nombre_actividad")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEtapaNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdEtapa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("actividades_ibfk_1");

                entity.HasOne(d => d.IdProfesionalNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdProfesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("actividades_ibfk_3");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("actividades_ibfk_2");
            });

            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PRIMARY");

                entity.ToTable("cargos");

                entity.Property(e => e.IdCargo)
                    .HasColumnName("Id_cargo")
                    .HasMaxLength(3);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<ContactoEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdContactoEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("contacto_empresa");

                entity.Property(e => e.IdContactoEmpresa)
                    .HasColumnName("Id_Contacto_empresa")
                    .HasMaxLength(6);

                entity.Property(e => e.ApellidosContactoEmpresa)
                    .HasColumnName("Apellidos_Contacto_empresa")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombresContactoEmpresa)
                    .HasColumnName("Nombres_Contacto_empresa")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.CódigoDepartamento)
                    .HasName("PRIMARY");

                entity.ToTable("departamento");

                entity.Property(e => e.CódigoDepartamento)
                    .HasColumnName("Código_Departamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreDepartamento)
                    .HasColumnName("Nombre_Departamento")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<EjeSeleccionado>(entity =>
            {
                entity.HasKey(e => e.IdEje)
                    .HasName("PRIMARY");

                entity.ToTable("eje_seleccionado");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("Id_proyecto");

                entity.Property(e => e.IdEje)
                    .HasColumnName("Id_eje")
                    .HasMaxLength(4);

                entity.Property(e => e.Eje)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdProyecto)
                    .IsRequired()
                    .HasColumnName("Id_proyecto")
                    .HasMaxLength(6);

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.EjeSeleccionado)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eje_seleccionado_ibfk_1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.HasIndex(e => e.CódigoDepartamento)
                    .HasName("Código_Departamento");

                entity.HasIndex(e => e.CódigoMunicipio)
                    .HasName("Código_Municipio");

                entity.HasIndex(e => e.IdEje)
                    .HasName("Id_eje");

                entity.HasIndex(e => e.IdProfesional)
                    .HasName("Id_profesional");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("Id_proyecto");

                entity.HasIndex(e => e.IdSector)
                    .HasName("Id_sector");

                entity.HasIndex(e => e.IdTamañoEmpresa)
                    .HasName("Id_Tamaño_empresa");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("Id_empresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CódigoDepartamento)
                    .HasColumnName("Código_Departamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CódigoMunicipio)
                    .HasColumnName("Código_Municipio")
                    .HasColumnType("int(11)");

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

                entity.Property(e => e.IdProfesional)
                    .IsRequired()
                    .HasColumnName("Id_profesional")
                    .HasMaxLength(4);

                entity.Property(e => e.IdProyecto)
                    .IsRequired()
                    .HasColumnName("Id_proyecto")
                    .HasMaxLength(6);

                entity.Property(e => e.IdSector)
                    .IsRequired()
                    .HasColumnName("Id_sector")
                    .HasMaxLength(3);

                entity.Property(e => e.IdTamañoEmpresa)
                    .IsRequired()
                    .HasColumnName("Id_Tamaño_empresa")
                    .HasMaxLength(6);

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreEmpresa)
                    .HasColumnName("Nombre_empresa")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CódigoDepartamentoNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.CódigoDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_1");

                entity.HasOne(d => d.CódigoMunicipioNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.CódigoMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_2");

                entity.HasOne(d => d.IdEjeNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdEje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_5");

                entity.HasOne(d => d.IdProfesionalNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdProfesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_7");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_6");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdSector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_3");

                entity.HasOne(d => d.IdTamañoEmpresaNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdTamañoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empresa_ibfk_4");
            });

            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => e.IdEstudio)
                    .HasName("PRIMARY");

                entity.ToTable("estudios");

                entity.Property(e => e.IdEstudio)
                    .HasColumnName("Id_estudio")
                    .HasMaxLength(4);

                entity.Property(e => e.Estudio)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Etapas>(entity =>
            {
                entity.HasKey(e => e.IdEtapa)
                    .HasName("PRIMARY");

                entity.ToTable("etapas");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("Id_proyecto");

                entity.Property(e => e.IdEtapa)
                    .HasColumnName("Id_etapa")
                    .HasMaxLength(4);

                entity.Property(e => e.DescripcionEtapa)
                    .HasColumnName("Descripcion_etapa")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdProyecto)
                    .IsRequired()
                    .HasColumnName("Id_proyecto")
                    .HasMaxLength(6);

                entity.Property(e => e.NombreEtapa)
                    .HasColumnName("Nombre_etapa")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Etapas)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("etapas_ibfk_1");
            });

            modelBuilder.Entity<Herramientas>(entity =>
            {
                entity.HasKey(e => e.IdHerramienta)
                    .HasName("PRIMARY");

                entity.ToTable("herramientas");

                entity.HasIndex(e => e.IdEje)
                    .HasName("Id_eje");

                entity.Property(e => e.IdHerramienta)
                    .HasColumnName("Id_herramienta")
                    .HasMaxLength(4);

                entity.Property(e => e.Herramienta).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEje)
                    .IsRequired()
                    .HasColumnName("Id_eje")
                    .HasMaxLength(4);

                entity.HasOne(d => d.IdEjeNavigation)
                    .WithMany(p => p.Herramientas)
                    .HasForeignKey(d => d.IdEje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("herramientas_ibfk_1");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.CódigoMunicipio)
                    .HasName("PRIMARY");

                entity.ToTable("municipio");

                entity.HasIndex(e => e.CódigoDepartamento)
                    .HasName("Código_Departamento");

                entity.Property(e => e.CódigoMunicipio)
                    .HasColumnName("Código_Municipio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CódigoDepartamento)
                    .HasColumnName("Código_Departamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreMunicipio)
                    .HasColumnName("Nombre_Municipio")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CódigoDepartamentoNavigation)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.CódigoDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("municipio_ibfk_1");
            });

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.HasKey(e => e.IdProfesional)
                    .HasName("PRIMARY");

                entity.ToTable("profesional");

                entity.HasIndex(e => e.IdCargo)
                    .HasName("Id_cargo");

                entity.HasIndex(e => e.IdEje)
                    .HasName("Id_eje");

                entity.HasIndex(e => e.IdEstudio)
                    .HasName("Id_estudio");

                entity.HasIndex(e => e.IdProfesion)
                    .HasName("Id_Profesion");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("Id_proyecto");

                entity.HasIndex(e => e.IdTipoDocumento)
                    .HasName("Id_Tipo_Documento");

                entity.HasIndex(e => e.NoDocumento)
                    .HasName("No_documento")
                    .IsUnique();

                entity.Property(e => e.IdProfesional)
                    .HasColumnName("Id_profesional")
                    .HasMaxLength(4);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdCargo)
                    .IsRequired()
                    .HasColumnName("Id_cargo")
                    .HasMaxLength(2);

                entity.Property(e => e.IdEje)
                    .IsRequired()
                    .HasColumnName("Id_eje")
                    .HasMaxLength(4);

                entity.Property(e => e.IdEstudio)
                    .IsRequired()
                    .HasColumnName("Id_estudio")
                    .HasMaxLength(4);

                entity.Property(e => e.IdProfesion)
                    .IsRequired()
                    .HasColumnName("Id_Profesion")
                    .HasMaxLength(4);

                entity.Property(e => e.IdProyecto)
                    .IsRequired()
                    .HasColumnName("Id_proyecto")
                    .HasMaxLength(6);

                entity.Property(e => e.IdTipoDocumento)
                    .HasColumnName("Id_Tipo_Documento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NoDocumento)
                    .HasColumnName("No_documento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Profesional)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesional_ibfk_4");

                entity.HasOne(d => d.IdEjeNavigation)
                    .WithMany(p => p.Profesional)
                    .HasForeignKey(d => d.IdEje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesional_ibfk_6");

                entity.HasOne(d => d.IdEstudioNavigation)
                    .WithMany(p => p.Profesional)
                    .HasForeignKey(d => d.IdEstudio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesional_ibfk_3");

                entity.HasOne(d => d.IdProfesionNavigation)
                    .WithMany(p => p.Profesional)
                    .HasForeignKey(d => d.IdProfesion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesional_ibfk_2");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Profesional)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesional_ibfk_5");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Profesional)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesional_ibfk_1");
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
                entity.HasKey(e => e.IdReprLegal)
                    .HasName("PRIMARY");

                entity.ToTable("representante_legal");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("Id_empresa");

                entity.HasIndex(e => e.IdTipoDocumento)
                    .HasName("Id_Tipo_Documento");

                entity.HasIndex(e => e.NoDocumento)
                    .HasName("No_documento")
                    .IsUnique();

                entity.Property(e => e.IdReprLegal)
                    .HasColumnName("Id_repr_legal")
                    .HasMaxLength(6);

                entity.Property(e => e.ApellidosRepresentanteLegal)
                    .HasColumnName("Apellidos_Representante_Legal")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("Id_empresa")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdTipoDocumento)
                    .HasColumnName("Id_Tipo_Documento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NoDocumento)
                    .HasColumnName("No_documento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombresRepresentanteLegal)
                    .HasColumnName("Nombres_Representante_Legal")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.RepresentanteLegal)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("representante_legal_ibfk_2");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.RepresentanteLegal)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("representante_legal_ibfk_1");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol)
                    .HasColumnName("Id_rol")
                    .HasMaxLength(6);

                entity.Property(e => e.DescripciónRol)
                    .HasColumnName("Descripción_Rol")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreRol)
                    .HasColumnName("Nombre_Rol")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.IdSector)
                    .HasName("PRIMARY");

                entity.ToTable("sector");

                entity.Property(e => e.IdSector)
                    .HasColumnName("Id_sector")
                    .HasMaxLength(3);

                entity.Property(e => e.Sector1)
                    .HasColumnName("Sector")
                    .HasMaxLength(50)
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

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_documento");

                entity.Property(e => e.IdTipoDocumento)
                    .HasColumnName("Id_Tipo_Documento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoDeDocumento)
                    .HasColumnName("Tipo_de_documento")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdProfesional)
                    .HasName("Id_profesional");

                entity.HasIndex(e => e.IdRol)
                    .HasName("Id_rol");

                entity.HasIndex(e => e.NoDocumento)
                    .HasName("No_documento")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .HasMaxLength(4);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdProfesional)
                    .IsRequired()
                    .HasColumnName("Id_profesional")
                    .HasMaxLength(4);

                entity.Property(e => e.IdRol)
                    .IsRequired()
                    .HasColumnName("Id_rol")
                    .HasMaxLength(6);

                entity.Property(e => e.NoDocumento)
                    .IsRequired()
                    .HasColumnName("No_documento")
                    .HasMaxLength(11);

                entity.HasOne(d => d.IdProfesionalNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdProfesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_ibfk_1");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
