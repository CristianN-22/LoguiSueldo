using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoguiSueldo.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AntiguedadConvenios",
                columns: table => new
                {
                    AntiguedadConvenioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvenioID = table.Column<int>(type: "int", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hasta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculaPorAnio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntiguedadConvenios", x => x.AntiguedadConvenioID);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sueldo_basico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoUnidad = table.Column<int>(type: "int", nullable: false),
                    CantUnidades = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    ConceptoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvenioID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreVariable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Asiento = table.Column<int>(type: "int", nullable: false),
                    Bloque = table.Column<int>(type: "int", nullable: false),
                    Inamobible = table.Column<bool>(type: "bit", nullable: false),
                    Remunerable = table.Column<bool>(type: "bit", nullable: false),
                    sel = table.Column<bool>(type: "bit", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.ConceptoID);
                });

            migrationBuilder.CreateTable(
                name: "ConceptosAfip",
                columns: table => new
                {
                    ConceptoAfip = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConceptoID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repeticion = table.Column<bool>(type: "bit", nullable: false),
                    AportesSipa = table.Column<bool>(type: "bit", nullable: false),
                    ContribucionSipa = table.Column<bool>(type: "bit", nullable: false),
                    AportesInssjyp = table.Column<bool>(type: "bit", nullable: false),
                    ContribucionInssjyp = table.Column<bool>(type: "bit", nullable: false),
                    AporteObraSocial = table.Column<bool>(type: "bit", nullable: false),
                    ContribucionObraSocial = table.Column<bool>(type: "bit", nullable: false),
                    AporteFondo = table.Column<bool>(type: "bit", nullable: false),
                    ContribucionFondo = table.Column<bool>(type: "bit", nullable: false),
                    AporteRenatae = table.Column<bool>(type: "bit", nullable: false),
                    ContribucionRenatae = table.Column<bool>(type: "bit", nullable: false),
                    ContribucionAsigFamiliar = table.Column<bool>(type: "bit", nullable: false),
                    ContribucionFondoEmpleo = table.Column<bool>(type: "bit", nullable: false),
                    ContribucionRiesgoTrabajo = table.Column<bool>(type: "bit", nullable: false),
                    AporteRegDiferencial = table.Column<bool>(type: "bit", nullable: false),
                    AporteRegEspeciales = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seleccion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptosAfip", x => x.ConceptoAfip);
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    ConvenioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.ConvenioID);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    PersonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvenioID = table.Column<int>(type: "int", nullable: false),
                    LocalidadID = table.Column<int>(type: "int", nullable: false),
                    ObraSocialID = table.Column<int>(type: "int", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    SistJubilID = table.Column<int>(type: "int", nullable: false),
                    ArtID = table.Column<int>(type: "int", nullable: false),
                    ModalidadID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    Legajo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuil = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLiquidacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Basico = table.Column<float>(type: "real", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoUltimoRecibo = table.Column<float>(type: "real", nullable: false),
                    UltimoPeriodoLiquidado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadHoras = table.Column<float>(type: "real", nullable: false),
                    PrecioHoras = table.Column<float>(type: "real", nullable: false),
                    AnioAntiguedad = table.Column<int>(type: "int", nullable: false),
                    PorcentajeAntiguedad = table.Column<float>(type: "real", nullable: false),
                    PorcentajeJubilacion = table.Column<float>(type: "real", nullable: false),
                    PorcentajeObraSocial = table.Column<float>(type: "real", nullable: false),
                    MontoHoraExtra = table.Column<float>(type: "real", nullable: false),
                    ModalidadLiquidacion = table.Column<int>(type: "int", nullable: false),
                    MontoHorasFeriado = table.Column<float>(type: "real", nullable: false),
                    MontoHorasFeriado_tjdo = table.Column<float>(type: "real", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAltaRecibo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Extra1 = table.Column<float>(type: "real", nullable: false),
                    Extra2 = table.Column<float>(type: "real", nullable: false),
                    Extra3 = table.Column<float>(type: "real", nullable: false),
                    Extra4 = table.Column<float>(type: "real", nullable: false),
                    Extra5 = table.Column<float>(type: "real", nullable: false),
                    Extra6 = table.Column<float>(type: "real", nullable: false),
                    HorasEnfAcc = table.Column<float>(type: "real", nullable: false),
                    Conyugue = table.Column<int>(type: "int", nullable: false),
                    Hijos = table.Column<int>(type: "int", nullable: false),
                    Cct = table.Column<int>(type: "int", nullable: false),
                    Reduccion = table.Column<int>(type: "int", nullable: false),
                    CodigoSituacion = table.Column<int>(type: "int", nullable: false),
                    CodigoCondicion = table.Column<int>(type: "int", nullable: false),
                    CodigoActividad = table.Column<int>(type: "int", nullable: false),
                    CodigoSiniestrado = table.Column<int>(type: "int", nullable: false),
                    CodigoContratacion = table.Column<int>(type: "int", nullable: false),
                    CodigoLocalidad = table.Column<int>(type: "int", nullable: false),
                    DiasTrabajados = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.PersonaID);
                });

            migrationBuilder.CreateTable(
                name: "Empleados_Adicional",
                columns: table => new
                {
                    PersonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSiniestro1 = table.Column<int>(type: "int", nullable: false),
                    DiaSiniestro1 = table.Column<int>(type: "int", nullable: false),
                    CodigoSiniestro2 = table.Column<int>(type: "int", nullable: false),
                    DiaSiniestro2 = table.Column<int>(type: "int", nullable: false),
                    CodigoSiniestro3 = table.Column<int>(type: "int", nullable: false),
                    DiaSiniestro3 = table.Column<int>(type: "int", nullable: false),
                    AporteAdicional_ss = table.Column<float>(type: "real", nullable: false),
                    ContribucionAdicional = table.Column<float>(type: "real", nullable: false),
                    AporteAdicionalObraSocial = table.Column<float>(type: "real", nullable: false),
                    ContribucionAdicionalObraSocial = table.Column<float>(type: "real", nullable: false),
                    BaseDiferencialAporte_os_fsr = table.Column<float>(type: "real", nullable: false),
                    BaseDiferencialContribucion_os_fsr = table.Column<float>(type: "real", nullable: false),
                    BaseDiferencial_lrt = table.Column<float>(type: "real", nullable: false),
                    MaternidadAnses = table.Column<float>(type: "real", nullable: false),
                    MediaJornada = table.Column<bool>(type: "bit", nullable: false),
                    TipoEmpleador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados_Adicional", x => x.PersonaID);
                });

            migrationBuilder.CreateTable(
                name: "Horas_Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorasFeriadoCant = table.Column<float>(type: "real", nullable: false),
                    HorasExtrasCant = table.Column<float>(type: "real", nullable: false),
                    HorasNormalesCant = table.Column<float>(type: "real", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    anio = table.Column<float>(type: "real", nullable: false),
                    HorasFeriadoTrabajado = table.Column<float>(type: "real", nullable: false),
                    HorasEnfermoCant = table.Column<float>(type: "real", nullable: false),
                    HorasAccCant = table.Column<float>(type: "real", nullable: false),
                    Km_Cantidad = table.Column<float>(type: "real", nullable: false),
                    Km_Cantidad_item424 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horas_Empleados", x => x.EmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "Leyes",
                columns: table => new
                {
                    LeyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leyes", x => x.LeyID);
                });

            migrationBuilder.CreateTable(
                name: "LibroSueldoAdicionales",
                columns: table => new
                {
                    LibroSueldoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaID = table.Column<int>(type: "int", nullable: false),
                    ReciboID = table.Column<int>(type: "int", nullable: false),
                    Cuil = table.Column<int>(type: "int", nullable: false),
                    Conyugue = table.Column<int>(type: "int", nullable: false),
                    Hijos = table.Column<int>(type: "int", nullable: false),
                    Cct = table.Column<int>(type: "int", nullable: false),
                    Svco = table.Column<int>(type: "int", nullable: false),
                    Reduccion = table.Column<int>(type: "int", nullable: false),
                    TipoEmpresa = table.Column<int>(type: "int", nullable: false),
                    CodSituacion = table.Column<int>(type: "int", nullable: false),
                    CodCondicion = table.Column<int>(type: "int", nullable: false),
                    CodActividad = table.Column<int>(type: "int", nullable: false),
                    CodSiniestrado = table.Column<int>(type: "int", nullable: false),
                    CodContratacion = table.Column<int>(type: "int", nullable: false),
                    CodLocalidad = table.Column<int>(type: "int", nullable: false),
                    DiasTrabajados = table.Column<int>(type: "int", nullable: false),
                    HorasTrabajadas = table.Column<float>(type: "real", nullable: false),
                    CantidadAdherentes = table.Column<int>(type: "int", nullable: false),
                    CodigoObraSocial = table.Column<int>(type: "int", nullable: false),
                    CodigoSiniestro1 = table.Column<int>(type: "int", nullable: false),
                    DiaSiniestro1 = table.Column<int>(type: "int", nullable: false),
                    CodigoSiniestro2 = table.Column<int>(type: "int", nullable: false),
                    DiaSiniestro2 = table.Column<int>(type: "int", nullable: false),
                    CodigoSiniestro3 = table.Column<int>(type: "int", nullable: false),
                    DiaSiniestro3 = table.Column<int>(type: "int", nullable: false),
                    AporteAdicional_ss = table.Column<float>(type: "real", nullable: false),
                    ContribucionAdicional = table.Column<float>(type: "real", nullable: false),
                    BaseDifAporte_os_fsr = table.Column<float>(type: "real", nullable: false),
                    BaseDifCont_os_fsr = table.Column<float>(type: "real", nullable: false),
                    BaseDif_lrt = table.Column<float>(type: "real", nullable: false),
                    MaternidadAnses = table.Column<float>(type: "real", nullable: false),
                    RemuneracionBruto = table.Column<float>(type: "real", nullable: false),
                    BaseImponible1 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible2 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible3 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible4 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible5 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible6 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible7 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible8 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible9 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible10 = table.Column<float>(type: "real", nullable: false),
                    BaseDifAportes_ss = table.Column<float>(type: "real", nullable: false),
                    BaseDifContribucion_ss = table.Column<float>(type: "real", nullable: false),
                    ImporteDetraer = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroSueldoAdicionales", x => x.LibroSueldoID);
                });

            migrationBuilder.CreateTable(
                name: "LibroSueldos",
                columns: table => new
                {
                    LibroSueldoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuitEmpleador = table.Column<float>(type: "real", nullable: false),
                    Identificador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Periodo = table.Column<float>(type: "real", nullable: false),
                    TipoLiquidador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroLiquidacion = table.Column<int>(type: "int", nullable: false),
                    DiasBase = table.Column<int>(type: "int", nullable: false),
                    Cantidad_reg_4 = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Ley = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroSueldos", x => x.LibroSueldoID);
                });

            migrationBuilder.CreateTable(
                name: "Modalidades",
                columns: table => new
                {
                    ModalidadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_afip = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.ModalidadID);
                });

            migrationBuilder.CreateTable(
                name: "ObrasSociales",
                columns: table => new
                {
                    ObraSocialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasSociales", x => x.ObraSocialID);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisID = table.Column<int>(type: "int", nullable: false),
                    PaisNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoDenominacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisID);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    PermisoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermisoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.PermisoID);
                });

            migrationBuilder.CreateTable(
                name: "PlantillaDetalles",
                columns: table => new
                {
                    PlantillaDetalleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantillaID = table.Column<int>(type: "int", nullable: false),
                    ConceptoID = table.Column<int>(type: "int", nullable: false),
                    Inputacion = table.Column<int>(type: "int", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUnidad = table.Column<int>(type: "int", nullable: false),
                    UnidadSubfijo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalcularUnidad = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantillaDetalles", x => x.PlantillaDetalleID);
                });

            migrationBuilder.CreateTable(
                name: "PlantillaEmpleados",
                columns: table => new
                {
                    PlantillaEmpleadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantillaID = table.Column<int>(type: "int", nullable: false),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    NombrePlan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantillaEmpleados", x => x.PlantillaEmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "Plantillas",
                columns: table => new
                {
                    PlantillaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<float>(type: "real", nullable: false),
                    ConvenioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantillas", x => x.PlantillaID);
                });

            migrationBuilder.CreateTable(
                name: "Recibo_Sueldos",
                columns: table => new
                {
                    ReciboID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    RemuneracionBruta = table.Column<float>(type: "real", nullable: false),
                    BaseImponible1 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible2 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible3 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible4 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible5 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible6 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible7 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible8 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible9 = table.Column<float>(type: "real", nullable: false),
                    BaseImponible10 = table.Column<float>(type: "real", nullable: false),
                    BaseDifAportes_ss = table.Column<float>(type: "real", nullable: false),
                    BaseDifContribucion_ss = table.Column<float>(type: "real", nullable: false),
                    ImporteDetraer = table.Column<float>(type: "real", nullable: false),
                    PeriodoMes = table.Column<int>(type: "int", nullable: false),
                    PeriodoAño = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo_Sueldos", x => x.ReciboID);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    ReciboID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    PlantillaID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    PeriodoMes = table.Column<int>(type: "int", nullable: false),
                    PeriodoAño = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    TotalRemunerativo = table.Column<float>(type: "real", nullable: false),
                    TotalRemunerativoSinExtra = table.Column<float>(type: "real", nullable: false),
                    TotalDescuento = table.Column<float>(type: "real", nullable: false),
                    TotalExtras = table.Column<float>(type: "real", nullable: false),
                    TotalBolsillo = table.Column<float>(type: "real", nullable: false),
                    LugarPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeposito = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombrePeriodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoLetras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoReciboDetalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpleadoCuit = table.Column<int>(type: "int", nullable: false),
                    EmpleadoFechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpleadoCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormaPago = table.Column<int>(type: "int", nullable: false),
                    DiasLiquidado = table.Column<float>(type: "real", nullable: false),
                    Cbu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.ReciboID);
                });

            migrationBuilder.CreateTable(
                name: "SistJubilatorios",
                columns: table => new
                {
                    SistJubilID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistJubilatorios", x => x.SistJubilID);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ProvinciaID = table.Column<int>(type: "int", nullable: false),
                    ProvinciaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ProvinciaID);
                    table.ForeignKey(
                        name: "FK_Provincias_Pais_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Pais",
                        principalColumn: "PaisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    LocalidadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalidadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.LocalidadID);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciaID",
                        column: x => x.ProvinciaID,
                        principalTable: "Provincias",
                        principalColumn: "ProvinciaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaIDLoguiGestion = table.Column<int>(type: "int", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NombreFantasia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DireccionReal = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LocalidadID = table.Column<int>(type: "int", nullable: false),
                    TipoContribuyenteID = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoID = table.Column<int>(type: "int", nullable: false),
                    NroTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgenteRetencionGanancias = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaID);
                    table.ForeignKey(
                        name: "FK_Empresas_Localidades_LocalidadID",
                        column: x => x.LocalidadID,
                        principalTable: "Localidades",
                        principalColumn: "LocalidadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NombreFantasia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DireccionReal = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LocalidadID = table.Column<int>(type: "int", nullable: false),
                    TipoContribuyenteID = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoID = table.Column<int>(type: "int", nullable: false),
                    NroTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaConsumidorFinal = table.Column<bool>(type: "bit", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaID);
                    table.ForeignKey(
                        name: "FK_Personas_Localidades_LocalidadID",
                        column: x => x.LocalidadID,
                        principalTable: "Localidades",
                        principalColumn: "LocalidadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermisoUsuarios",
                columns: table => new
                {
                    PermisoUsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaID = table.Column<int>(type: "int", nullable: false),
                    PermisoID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    UsuarioCarga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Digitos = table.Column<int>(type: "int", nullable: false),
                    CodigoSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolicitarCodigo = table.Column<int>(type: "int", nullable: false),
                    Desvinculado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoUsuarios", x => x.PermisoUsuarioID);
                    table.ForeignKey(
                        name: "FK_PermisoUsuarios_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermisoUsuarios_Permisos_PermisoID",
                        column: x => x.PermisoID,
                        principalTable: "Permisos",
                        principalColumn: "PermisoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_LocalidadID",
                table: "Empresas",
                column: "LocalidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaID",
                table: "Localidades",
                column: "ProvinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_PermisoUsuarios_EmpresaID",
                table: "PermisoUsuarios",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_PermisoUsuarios_PermisoID",
                table: "PermisoUsuarios",
                column: "PermisoID");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_LocalidadID",
                table: "Personas",
                column: "LocalidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_PaisID",
                table: "Provincias",
                column: "PaisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntiguedadConvenios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Conceptos");

            migrationBuilder.DropTable(
                name: "ConceptosAfip");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Empleados_Adicional");

            migrationBuilder.DropTable(
                name: "Horas_Empleados");

            migrationBuilder.DropTable(
                name: "Leyes");

            migrationBuilder.DropTable(
                name: "LibroSueldoAdicionales");

            migrationBuilder.DropTable(
                name: "LibroSueldos");

            migrationBuilder.DropTable(
                name: "Modalidades");

            migrationBuilder.DropTable(
                name: "ObrasSociales");

            migrationBuilder.DropTable(
                name: "PermisoUsuarios");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "PlantillaDetalles");

            migrationBuilder.DropTable(
                name: "PlantillaEmpleados");

            migrationBuilder.DropTable(
                name: "Plantillas");

            migrationBuilder.DropTable(
                name: "Recibo_Sueldos");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "SistJubilatorios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
