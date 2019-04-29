using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSS.Migrations
{
    public partial class Proyectos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(nullable: false),
                    IdObra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreObra = table.Column<string>(maxLength: 255, nullable: true),
                    NumOt = table.Column<string>(maxLength: 50, nullable: true),
                    Cliente = table.Column<string>(maxLength: 255, nullable: true),
                    DireccionObra = table.Column<string>(maxLength: 255, nullable: true),
                    CiudadObra = table.Column<string>(maxLength: 255, nullable: true),
                    ProvinciaObra = table.Column<string>(maxLength: 255, nullable: true),
                    CpObra = table.Column<string>(maxLength: 50, nullable: true),
                    Promotor = table.Column<string>(maxLength: 255, nullable: true),
                    AutorProyecto = table.Column<string>(maxLength: 255, nullable: true),
                    Tecnico = table.Column<string>(maxLength: 255, nullable: true),
                    PEM_PEC = table.Column<string>(maxLength: 50, nullable: true),
                    Presupuesto = table.Column<decimal>(type: "money", nullable: true),
                    Duracion = table.Column<int>(nullable: true),
                    Autor = table.Column<string>(maxLength: 255, nullable: true),
                    CSSFaseProyecto = table.Column<string>(maxLength: 255, nullable: true),
                    NumTrabajadores = table.Column<int>(nullable: true),
                    Contratista = table.Column<string>(maxLength: 255, nullable: true),
                    DireccionContratista = table.Column<string>(maxLength: 255, nullable: true),
                    CiudadContratista = table.Column<string>(maxLength: 255, nullable: true),
                    ProvinciaContratista = table.Column<string>(maxLength: 255, nullable: true),
                    CpContratista = table.Column<string>(maxLength: 5, nullable: true),
                    JefeObra = table.Column<string>(maxLength: 255, nullable: true),
                    Encargado = table.Column<string>(maxLength: 255, nullable: true),
                    RecursoPreventivo = table.Column<string>(maxLength: 255, nullable: true),
                    TipoObra = table.Column<string>(maxLength: 255, nullable: true),
                    DescripcionObra = table.Column<string>(nullable: true),
                    DescripcionLugar = table.Column<string>(nullable: true),
                    Superficie = table.Column<string>(maxLength: 50, nullable: true),
                    LinderoNorte = table.Column<string>(maxLength: 255, nullable: true),
                    LinderoSur = table.Column<string>(maxLength: 255, nullable: true),
                    LinderoEste = table.Column<string>(maxLength: 255, nullable: true),
                    LinderoOeste = table.Column<string>(maxLength: 255, nullable: true),
                    TraficoRodado = table.Column<string>(nullable: true),
                    Climatologia = table.Column<string>(nullable: true),
                    CaracteristicasTerreno = table.Column<string>(nullable: true),
                    AccesosRodados = table.Column<bool>(nullable: false),
                    CirculacionesPeatonales = table.Column<bool>(nullable: false),
                    LinElectAereas = table.Column<bool>(nullable: false),
                    LinElectEnterradas = table.Column<bool>(nullable: false),
                    Transformadores = table.Column<bool>(nullable: false),
                    LineasTelefonicas = table.Column<bool>(nullable: false),
                    ConduccionesGas = table.Column<bool>(nullable: false),
                    Alcantarillado = table.Column<bool>(nullable: false),
                    InstProviAreasAux = table.Column<bool>(nullable: false),
                    TipoEstudio = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.IdEmpresa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
