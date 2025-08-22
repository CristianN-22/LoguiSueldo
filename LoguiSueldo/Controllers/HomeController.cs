using LoguiSueldo.Data;
using LoguiSueldo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LoguiSueldo.Controllers
{
    public class HomeController : Controller
    {

        private readonly LoguiSueldoContext db;

        private EmpresasController EmpresasController;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index(string code, bool Graficos = false, bool GraficosStore = false)
        {

            var usuarioactual = User.Identity.GetUserId();

            Empresa empresa = new Empresa();
            PermisoUsuario permisoUsuario = new PermisoUsuario();
            if (EmpresasController.InformacionEmpresaActual(usuarioactual, empresa, permisoUsuario) == false)
            {
                return RedirectToAction("SeleccionaEmpresa", "Manage", new { id = empresa.EmpresaID });
            }
            if (empresa.EmpresaID == 0)
            {
                return RedirectToAction("Index", "Manage");
            }

            // ENCABEZADO IMPRESION.
            var membreteEmpresa = new ListadoPersonas
            {
                NombreCompleto = empresa.NombreFinal,
                DireccionReal = empresa.DireccionReal + " - " + empresa.Localidades.LocalidadNombre + " - " + empresa.Localidades.Provincias.ProvinciaNombre,
                Telefono = empresa.Telefono1
            };
            ViewBag.Empresa = membreteEmpresa;
            // FIN ENCABEZADO IMPRESION.

            List<ComboGeneral> cantidad = new List<ComboGeneral>();
            cantidad.Add(new ComboGeneral { ID = 0, Descripcion = "Todos" });
            cantidad.Add(new ComboGeneral { ID = 10, Descripcion = "Primeros 10" });
            cantidad.Add(new ComboGeneral { ID = 20, Descripcion = "Primeros 20" });
            cantidad.Add(new ComboGeneral { ID = 50, Descripcion = "Primeros 50" });
            cantidad = cantidad.OrderBy(e => e.ID).ToList();
            ViewBag.FiltroCantidad = new SelectList(cantidad, "ID", "Descripcion", 10);

            ViewBag.EmpresaID = empresa.EmpresaID;
            ViewBag.PermisoID = permisoUsuario.PermisoID;
            ViewBag.UsuarioID = usuarioactual;

            //var tiposContribuyentes = (from o in db.TipoContribuyentes where o.Visible == true && o.TipoContribuyenteID != 5 select o).ToList();
            //ViewBag.TipoContribuyenteIDAfip = new SelectList(tiposContribuyentes.OrderBy(t => t.TipoContribuyenteNombre), "TipoContribuyenteID", "TipoContribuyenteNombre", 1);

            var usuariosEmpresa = (from usu in db.PermisoUsuarios where usu.EmpresaID == empresa.EmpresaID && usu.Desvinculado == false select usu).ToList();
            //List<Persona> vendedores = new List<Persona>();
            //foreach (var u in usuariosEmpresa)
            //{
             //   if (u.PersonaID > 0)
             //   {
             //       var vendedor = (from cam in db.Personas where cam.PersonaID == u.PersonaID && cam.EmpresaID == empresa.EmpresaID select cam).Single();
            //        vendedores.Add(vendedor);
            //    }
            //}
            //vendedores = vendedores.OrderBy(a => a.NombreCompleto).ToList();
            //ViewBag.VendedorID = new SelectList(vendedores, "PersonaID", "NombreCompleto", permisoUsuario.PersonaID);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
