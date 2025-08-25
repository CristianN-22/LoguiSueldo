using LoguiSueldo.Models;
using LoguiSueldo.Models.Administracion;
using Microsoft.EntityFrameworkCore;

namespace LoguiSueldo.Data
{
    public class LoguiSueldoContext: DbContext
    {
        public LoguiSueldoContext(DbContextOptions<LoguiSueldoContext> options)
            : base(options)
        {

        }

        public DbSet<ClientesLogui> ClientesLogui { get; set; }
        public DbSet<Persona> Personas { get; set; }

        public DbSet<Permiso> Permisos { get; set; }

        public DbSet<PermisoUsuario> PermisoUsuarios { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Empleado_Adicional> Empleados_Adicional { get; set; }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaOnline> EmpresasOnline { get; set; }

        public DbSet<Pais> Pais { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Localidad> Localidades { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        //Informacion necesaria

        public DbSet<ART> ARTs { get; set; }
        public DbSet<Concepto_Afip> ConceptosAfip { get; set; }

        public DbSet<Conceptos> Conceptos { get; set; }

        public DbSet<Convenio> Convenios { get; set; }

        public DbSet<Antiguedad_Convenio> AntiguedadConvenios { get; set; }

        public DbSet<Horas_empleados> Horas_Empleados { get; set; }

        public DbSet<Leyes> Leyes { get; set; }

        public DbSet<Sist_jubil> SistJubilatorios { get; set; }

        public DbSet<Modalidad> Modalidades { get; set; }

        public DbSet<Obra_social> ObrasSociales { get; set; }

        //Liquidacion
        public DbSet<Libro_sueldo> LibroSueldos { get; set; }

        public DbSet<Libro_sueldo_adicional> LibroSueldoAdicionales { get; set; }

        public DbSet<Plantilla> Plantillas { get; set; }

        public DbSet<Plantilla_Detalle> PlantillaDetalles { get; set; }

        public DbSet<Plantilla_empleado> PlantillaEmpleados { get; set; }

        public DbSet<Recibo> Recibos { get; set; }

        public DbSet<Recibo_Sueldo_DatosAdicionales> Recibo_Sueldos { get; set; }

    }

}
