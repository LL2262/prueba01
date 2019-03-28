using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pruebaempleadosbe.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    LocalidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.LocalidadID);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    PuestoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.PuestoID);
                });

            migrationBuilder.CreateTable(
                name: "Barrios",
                columns: table => new
                {
                    BarrioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    idLocalidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrios", x => x.BarrioID);
                    table.ForeignKey(
                        name: "FK_Barrios_Localidades_idLocalidad",
                        column: x => x.idLocalidad,
                        principalTable: "Localidades",
                        principalColumn: "LocalidadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    DomicilioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    calle = table.Column<int>(nullable: false),
                    numero = table.Column<int>(nullable: false),
                    idBarrio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.DomicilioID);
                    table.ForeignKey(
                        name: "FK_Domicilios_Barrios_idBarrio",
                        column: x => x.idBarrio,
                        principalTable: "Barrios",
                        principalColumn: "BarrioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    legajo = table.Column<int>(nullable: false),
                    dni = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    fechaNac = table.Column<string>(nullable: true),
                    idDomicilio = table.Column<int>(nullable: false),
                    idPuesto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleados_Domicilios_idDomicilio",
                        column: x => x.idDomicilio,
                        principalTable: "Domicilios",
                        principalColumn: "DomicilioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Puestos_idPuesto",
                        column: x => x.idPuesto,
                        principalTable: "Puestos",
                        principalColumn: "PuestoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_idLocalidad",
                table: "Barrios",
                column: "idLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_idBarrio",
                table: "Domicilios",
                column: "idBarrio");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_idDomicilio",
                table: "Empleados",
                column: "idDomicilio");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_idPuesto",
                table: "Empleados",
                column: "idPuesto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Barrios");

            migrationBuilder.DropTable(
                name: "Localidades");
        }
    }
}
