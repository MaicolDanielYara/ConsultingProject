using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ConsultingProject.Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    Id_cargo = table.Column<string>(maxLength: 3, nullable: false),
                    Cargo = table.Column<string>(maxLength: 30, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_cargo);
                });

            migrationBuilder.CreateTable(
                name: "contacto_empresa",
                columns: table => new
                {
                    Id_Contacto_empresa = table.Column<string>(maxLength: 6, nullable: false),
                    Nombres_Contacto_empresa = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Apellidos_Contacto_empresa = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Correo = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Contacto_empresa);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Código_Departamento = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Departamento = table.Column<string>(maxLength: 25, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Código_Departamento);
                });

            migrationBuilder.CreateTable(
                name: "estudios",
                columns: table => new
                {
                    Id_estudio = table.Column<string>(maxLength: 4, nullable: false),
                    Estudio = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_estudio);
                });

            migrationBuilder.CreateTable(
                name: "profesiones",
                columns: table => new
                {
                    Id_Profesion = table.Column<string>(maxLength: 4, nullable: false),
                    Profesion = table.Column<string>(maxLength: 30, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Profesion);
                });

            migrationBuilder.CreateTable(
                name: "proyecto",
                columns: table => new
                {
                    Id_proyecto = table.Column<string>(maxLength: 6, nullable: false),
                    Nombre_proyecto = table.Column<string>(maxLength: 15, nullable: true, defaultValueSql: "'NULL'"),
                    No_Convenio = table.Column<string>(maxLength: 10, nullable: true, defaultValueSql: "'NULL'"),
                    Objeto = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    Fecha_inicio = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    Plazo_Ejecucion = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Presupuesto = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_proyecto);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id_rol = table.Column<string>(maxLength: 6, nullable: false),
                    Nombre_Rol = table.Column<string>(maxLength: 15, nullable: true, defaultValueSql: "'NULL'"),
                    Descripción_Rol = table.Column<string>(nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_rol);
                });

            migrationBuilder.CreateTable(
                name: "sector",
                columns: table => new
                {
                    Id_sector = table.Column<string>(maxLength: 3, nullable: false),
                    Sector = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_sector);
                });

            migrationBuilder.CreateTable(
                name: "tamaño_empresa",
                columns: table => new
                {
                    Id_Tamaño_empresa = table.Column<string>(maxLength: 6, nullable: false),
                    Tamaño_empresa = table.Column<string>(maxLength: 15, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Tamaño_empresa);
                });

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                columns: table => new
                {
                    Id_Tipo_Documento = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tipo_de_documento = table.Column<string>(maxLength: 25, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Tipo_Documento);
                });

            migrationBuilder.CreateTable(
                name: "municipio",
                columns: table => new
                {
                    Código_Municipio = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Municipio = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Código_Departamento = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Código_Municipio);
                    table.ForeignKey(
                        name: "municipio_ibfk_1",
                        column: x => x.Código_Departamento,
                        principalTable: "departamento",
                        principalColumn: "Código_Departamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "eje_seleccionado",
                columns: table => new
                {
                    Id_eje = table.Column<string>(maxLength: 4, nullable: false),
                    Eje = table.Column<string>(maxLength: 25, nullable: true, defaultValueSql: "'NULL'"),
                    Id_proyecto = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_eje);
                    table.ForeignKey(
                        name: "eje_seleccionado_ibfk_1",
                        column: x => x.Id_proyecto,
                        principalTable: "proyecto",
                        principalColumn: "Id_proyecto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "etapas",
                columns: table => new
                {
                    Id_etapa = table.Column<string>(maxLength: 4, nullable: false),
                    Nombre_etapa = table.Column<string>(maxLength: 15, nullable: true, defaultValueSql: "'NULL'"),
                    Descripcion_etapa = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    Id_proyecto = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_etapa);
                    table.ForeignKey(
                        name: "etapas_ibfk_1",
                        column: x => x.Id_proyecto,
                        principalTable: "proyecto",
                        principalColumn: "Id_proyecto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "herramientas",
                columns: table => new
                {
                    Id_herramienta = table.Column<string>(maxLength: 4, nullable: false),
                    Herramienta = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    Id_eje = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_herramienta);
                    table.ForeignKey(
                        name: "herramientas_ibfk_1",
                        column: x => x.Id_eje,
                        principalTable: "eje_seleccionado",
                        principalColumn: "Id_eje",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "profesional",
                columns: table => new
                {
                    Id_profesional = table.Column<string>(maxLength: 4, nullable: false),
                    Nombres = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Apellidos = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Id_Tipo_Documento = table.Column<int>(type: "int(11)", nullable: false),
                    No_documento = table.Column<int>(type: "int(11)", nullable: false),
                    Correo = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true, defaultValueSql: "'NULL'"),
                    Id_Profesion = table.Column<string>(maxLength: 4, nullable: false),
                    Id_estudio = table.Column<string>(maxLength: 4, nullable: false),
                    Id_cargo = table.Column<string>(maxLength: 2, nullable: false),
                    Id_proyecto = table.Column<string>(maxLength: 6, nullable: false),
                    Id_eje = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_profesional);
                    table.ForeignKey(
                        name: "profesional_ibfk_4",
                        column: x => x.Id_cargo,
                        principalTable: "cargos",
                        principalColumn: "Id_cargo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "profesional_ibfk_6",
                        column: x => x.Id_eje,
                        principalTable: "eje_seleccionado",
                        principalColumn: "Id_eje",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "profesional_ibfk_3",
                        column: x => x.Id_estudio,
                        principalTable: "estudios",
                        principalColumn: "Id_estudio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "profesional_ibfk_2",
                        column: x => x.Id_Profesion,
                        principalTable: "profesiones",
                        principalColumn: "Id_Profesion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "profesional_ibfk_5",
                        column: x => x.Id_proyecto,
                        principalTable: "proyecto",
                        principalColumn: "Id_proyecto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "profesional_ibfk_1",
                        column: x => x.Id_Tipo_Documento,
                        principalTable: "tipo_documento",
                        principalColumn: "Id_Tipo_Documento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "actividades",
                columns: table => new
                {
                    Id_actividad = table.Column<string>(maxLength: 6, nullable: false),
                    nombre_actividad = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    Descripcion_actividad = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    Id_etapa = table.Column<string>(maxLength: 4, nullable: false),
                    Id_proyecto = table.Column<string>(maxLength: 6, nullable: false),
                    Id_profesional = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_actividad);
                    table.ForeignKey(
                        name: "actividades_ibfk_1",
                        column: x => x.Id_etapa,
                        principalTable: "etapas",
                        principalColumn: "Id_etapa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "actividades_ibfk_3",
                        column: x => x.Id_profesional,
                        principalTable: "profesional",
                        principalColumn: "Id_profesional",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "actividades_ibfk_2",
                        column: x => x.Id_proyecto,
                        principalTable: "proyecto",
                        principalColumn: "Id_proyecto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    Id_empresa = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_empresa = table.Column<string>(maxLength: 15, nullable: true, defaultValueSql: "'NULL'"),
                    NIT = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Digito_verificacion = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Fechaconstlegal = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    Código_Departamento = table.Column<int>(type: "int(11)", nullable: false),
                    Código_Municipio = table.Column<int>(type: "int(11)", nullable: false),
                    Id_sector = table.Column<string>(maxLength: 3, nullable: false),
                    Id_Tamaño_empresa = table.Column<string>(maxLength: 6, nullable: false),
                    Id_eje = table.Column<string>(maxLength: 4, nullable: false),
                    Id_proyecto = table.Column<string>(maxLength: 6, nullable: false),
                    Id_profesional = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_empresa);
                    table.ForeignKey(
                        name: "empresa_ibfk_1",
                        column: x => x.Código_Departamento,
                        principalTable: "departamento",
                        principalColumn: "Código_Departamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "empresa_ibfk_2",
                        column: x => x.Código_Municipio,
                        principalTable: "municipio",
                        principalColumn: "Código_Municipio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "empresa_ibfk_5",
                        column: x => x.Id_eje,
                        principalTable: "eje_seleccionado",
                        principalColumn: "Id_eje",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "empresa_ibfk_7",
                        column: x => x.Id_profesional,
                        principalTable: "profesional",
                        principalColumn: "Id_profesional",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "empresa_ibfk_6",
                        column: x => x.Id_proyecto,
                        principalTable: "proyecto",
                        principalColumn: "Id_proyecto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "empresa_ibfk_3",
                        column: x => x.Id_sector,
                        principalTable: "sector",
                        principalColumn: "Id_sector",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "empresa_ibfk_4",
                        column: x => x.Id_Tamaño_empresa,
                        principalTable: "tamaño_empresa",
                        principalColumn: "Id_Tamaño_empresa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<string>(maxLength: 4, nullable: false),
                    No_documento = table.Column<string>(maxLength: 11, nullable: false),
                    Contraseña = table.Column<string>(maxLength: 8, nullable: true, defaultValueSql: "'NULL'"),
                    Id_profesional = table.Column<string>(maxLength: 4, nullable: false),
                    Id_rol = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "usuario_ibfk_1",
                        column: x => x.Id_profesional,
                        principalTable: "profesional",
                        principalColumn: "Id_profesional",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "usuario_ibfk_2",
                        column: x => x.Id_rol,
                        principalTable: "rol",
                        principalColumn: "Id_rol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "representante_legal",
                columns: table => new
                {
                    Id_repr_legal = table.Column<string>(maxLength: 6, nullable: false),
                    Nombres_Representante_Legal = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Apellidos_Representante_Legal = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Id_Tipo_Documento = table.Column<int>(type: "int(11)", nullable: false),
                    No_documento = table.Column<int>(type: "int(11)", nullable: false),
                    Correo = table.Column<string>(maxLength: 40, nullable: true, defaultValueSql: "'NULL'"),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true, defaultValueSql: "'NULL'"),
                    Id_empresa = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_repr_legal);
                    table.ForeignKey(
                        name: "representante_legal_ibfk_2",
                        column: x => x.Id_empresa,
                        principalTable: "empresa",
                        principalColumn: "Id_empresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "representante_legal_ibfk_1",
                        column: x => x.Id_Tipo_Documento,
                        principalTable: "tipo_documento",
                        principalColumn: "Id_Tipo_Documento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Id_etapa",
                table: "actividades",
                column: "Id_etapa");

            migrationBuilder.CreateIndex(
                name: "Id_profesional",
                table: "actividades",
                column: "Id_profesional");

            migrationBuilder.CreateIndex(
                name: "Id_proyecto",
                table: "actividades",
                column: "Id_proyecto");

            migrationBuilder.CreateIndex(
                name: "Id_proyecto",
                table: "eje_seleccionado",
                column: "Id_proyecto");

            migrationBuilder.CreateIndex(
                name: "Código_Departamento",
                table: "empresa",
                column: "Código_Departamento");

            migrationBuilder.CreateIndex(
                name: "Código_Municipio",
                table: "empresa",
                column: "Código_Municipio");

            migrationBuilder.CreateIndex(
                name: "Id_eje",
                table: "empresa",
                column: "Id_eje");

            migrationBuilder.CreateIndex(
                name: "Id_profesional",
                table: "empresa",
                column: "Id_profesional");

            migrationBuilder.CreateIndex(
                name: "Id_proyecto",
                table: "empresa",
                column: "Id_proyecto");

            migrationBuilder.CreateIndex(
                name: "Id_sector",
                table: "empresa",
                column: "Id_sector");

            migrationBuilder.CreateIndex(
                name: "Id_Tamaño_empresa",
                table: "empresa",
                column: "Id_Tamaño_empresa");

            migrationBuilder.CreateIndex(
                name: "Id_proyecto",
                table: "etapas",
                column: "Id_proyecto");

            migrationBuilder.CreateIndex(
                name: "Id_eje",
                table: "herramientas",
                column: "Id_eje");

            migrationBuilder.CreateIndex(
                name: "Código_Departamento",
                table: "municipio",
                column: "Código_Departamento");

            migrationBuilder.CreateIndex(
                name: "Id_cargo",
                table: "profesional",
                column: "Id_cargo");

            migrationBuilder.CreateIndex(
                name: "Id_eje",
                table: "profesional",
                column: "Id_eje");

            migrationBuilder.CreateIndex(
                name: "Id_estudio",
                table: "profesional",
                column: "Id_estudio");

            migrationBuilder.CreateIndex(
                name: "Id_Profesion",
                table: "profesional",
                column: "Id_Profesion");

            migrationBuilder.CreateIndex(
                name: "Id_proyecto",
                table: "profesional",
                column: "Id_proyecto");

            migrationBuilder.CreateIndex(
                name: "Id_Tipo_Documento",
                table: "profesional",
                column: "Id_Tipo_Documento");

            migrationBuilder.CreateIndex(
                name: "No_documento",
                table: "profesional",
                column: "No_documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_empresa",
                table: "representante_legal",
                column: "Id_empresa");

            migrationBuilder.CreateIndex(
                name: "Id_Tipo_Documento",
                table: "representante_legal",
                column: "Id_Tipo_Documento");

            migrationBuilder.CreateIndex(
                name: "No_documento",
                table: "representante_legal",
                column: "No_documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_profesional",
                table: "usuario",
                column: "Id_profesional");

            migrationBuilder.CreateIndex(
                name: "Id_rol",
                table: "usuario",
                column: "Id_rol");

            migrationBuilder.CreateIndex(
                name: "No_documento",
                table: "usuario",
                column: "No_documento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actividades");

            migrationBuilder.DropTable(
                name: "contacto_empresa");

            migrationBuilder.DropTable(
                name: "herramientas");

            migrationBuilder.DropTable(
                name: "representante_legal");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "etapas");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "municipio");

            migrationBuilder.DropTable(
                name: "profesional");

            migrationBuilder.DropTable(
                name: "sector");

            migrationBuilder.DropTable(
                name: "tamaño_empresa");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "eje_seleccionado");

            migrationBuilder.DropTable(
                name: "estudios");

            migrationBuilder.DropTable(
                name: "profesiones");

            migrationBuilder.DropTable(
                name: "tipo_documento");

            migrationBuilder.DropTable(
                name: "proyecto");
        }
    }
}
