using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using LoguiSueldo.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Threading;
using System.Globalization;
using LoguiSueldo.Models.Administracion;
using LoguiSueldo.Data;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Org.BouncyCastle.Crypto.Tls;
//using System.Web.Routing;


namespace LoguiSueldo.Controllers
{
    //[Authorize]  Esto es mintras programamos
    [AllowAnonymous]
    public class EmpresasController : Controller 
    {
        private readonly LoguiSueldoContext db;

        public EmpresasController(LoguiSueldoContext context)
        {
            db = context;
        }

        public bool InformacionEmpresaActual(string UsuarioID, Empresa empresa, PermisoUsuario permisoUsuario)
        {
            var existeEmpresaOnline = (from usu in db.EmpresasOnline where usu.UsuarioOnline == UsuarioID select usu).ToList();
            if (existeEmpresaOnline.Count == 1)
            {
                var empresaOnline = existeEmpresaOnline[0];

                var empresaActual = (from usu in db.Empresas where usu.EmpresaID == empresaOnline.EmpresaID select usu).Single();

                empresa.EmpresaID = empresaActual.EmpresaID;
                empresa.RazonSocial = empresaActual.RazonSocial;
                //empresa.TipoContribuyentes = empresaActual.TipoContribuyentes;
                //empresa.TipoContribuyenteID = empresaActual.TipoContribuyenteID;
                empresa.TipoDocumentoID = empresaActual.TipoDocumentoID;
                empresa.NroTipoDocumento = empresaActual.NroTipoDocumento;

                empresa.NombreFantasia = empresaActual.NombreFantasia;
                empresa.DireccionReal = empresaActual.DireccionReal;
                empresa.Telefono1 = empresaActual.Telefono1;
                empresa.CorreoElectronico = empresaActual.CorreoElectronico;
                empresa.LocalidadID = empresaActual.LocalidadID;
                empresa.Localidades = empresaActual.Localidades;
                empresa.UsuarioTitular = empresaActual.UsuarioTitular;
                //empresa.EmpresaIDLoguiGestion = empresaActual.EmpresaIDLoguiGestion;

                //permiso usuario actual
                var permiso = (from usu in db.PermisoUsuarios where usu.EmpresaID == empresaOnline.EmpresaID && usu.UsuarioID == UsuarioID && usu.Desvinculado == false select usu).Single();

                permisoUsuario.PermisoID = permiso.PermisoID;
                permisoUsuario.PersonaID = permiso.PersonaID;

            }

            return true;
        }
        public void EmpresaActual(string UsuarioID, Empresa empresa)
        {
            var existeEmpresaOnline = (from usu in db.EmpresasOnline where usu.UsuarioOnline == UsuarioID select usu).ToList();
            if (existeEmpresaOnline.Count == 1)
            {
                var empresaOnline = existeEmpresaOnline[0];

                var empresaActual = (from usu in db.Empresas where usu.EmpresaID == empresaOnline.EmpresaID select usu).Single();

                empresa.EmpresaID = empresaActual.EmpresaID;
                empresa.RazonSocial = empresaActual.RazonSocial;
                //empresa.TipoContribuyentes = empresaActual.TipoContribuyentes;
                //empresa.TipoContribuyenteID = empresaActual.TipoContribuyenteID;
                empresa.TipoDocumentoID = empresaActual.TipoDocumentoID;
                empresa.NroTipoDocumento = empresaActual.NroTipoDocumento;
                empresa.CorreoElectronico = empresaActual.CorreoElectronico;

                empresa.NombreFantasia = empresaActual.NombreFantasia;
                empresa.DireccionReal = empresaActual.DireccionReal;
                empresa.LocalidadID = empresaActual.LocalidadID;
                empresa.Localidades = empresaActual.Localidades;
                empresa.Telefono1 = empresaActual.Telefono1;
                empresa.UsuarioTitular = empresaActual.UsuarioTitular;
                //empresa.EmpresaIDLoguiGestion = empresaActual.EmpresaIDLoguiGestion;
            }
        }

        public ActionResult Index()
        {
            var usuarioactual = User.Identity.GetUserId();

            Empresa empresa = new Empresa();
            PermisoUsuario permisoUsuario = new PermisoUsuario();
            if (InformacionEmpresaActual(usuarioactual, empresa, permisoUsuario) == false)
            {
                //return RedirectToAction("SeleccionaEmpresa", "Manage", new { id = empresa.EmpresaID });
                // return RedirectToAction("LibroDiario", "Index", new { id = empresa.EmpresaID });
            }

            ViewBag.EmpresaID = empresa.EmpresaID;
            ViewBag.PermisoID = permisoUsuario.PermisoID;

            ViewBag.Empresa = empresa.RazonSocial;

            return View("~/Views/Empresas/Index.cshtml");
        }

        //BUSCAR INFORMACION DE LA EMPRESA LOGUEADA ACTUALMENTE MOSTRANDO TAMBIEN LOS USUARIOS RELACIONADOS
        public JsonResult EmpresasUsuario()
        {
            var usuarioactual = User.Identity.GetUserId();

            Empresa empresa = new Empresa();
            EmpresaActual(usuarioactual, empresa);

            List<ListadoEmpresaUsuario> listado = new List<ListadoEmpresaUsuario>();

            var personas = db.Personas.Where(p => p.EmpresaID == empresa.EmpresaID).ToList();

            List<ListadoPersonas> personasEmpresa = new List<ListadoPersonas>();

            var tablaPersonasEmpresa = (from cam in db.PermisoUsuarios where cam.EmpresaID == empresa.EmpresaID && cam.Desvinculado == false select cam).ToList();
            foreach (var p in tablaPersonasEmpresa)
            {
                if (p.PersonaID != 0)
                {
                    var persona = (from cam in personas where cam.PersonaID == p.PersonaID select cam).Single();

                    var personaEmpresa = new ListadoPersonas
                    {
                        PersonaID = p.PersonaID,
                        NombreCompleto = persona.NombreCompleto,
                        PermisoID = p.PermisoID,
                        PermisoNombre = p.Permiso.PermisoNombre
                    };
                    personasEmpresa.Add(personaEmpresa);
                }
            }

            var empresaMostrar = (from cam in db.Empresas where cam.EmpresaID == empresa.EmpresaID select cam).Single();
            var itemEmpresa = new ListadoEmpresaUsuario
            {
                EmpresaID = empresaMostrar.EmpresaID,
                RazonSocial = empresaMostrar.RazonSocial,
                //TipoContribuyenteNombre = empresaMostrar.TipoContribuyentes.TipoContribuyenteNombre,
                //TipoDocumentoNombre = empresaMostrar.TipoDocumentos.TipoDocumentoNombre,
                NroTipoDocumento = empresaMostrar.NroTipoDocumento,
                PersonasEmpresa = personasEmpresa
            };
            listado.Add(itemEmpresa);

            return Json(listado);
        }

        public ActionResult Edit(int? id)
        {
            var usuarioactual = User.Identity.GetUserId();

            Empresa empresaActual = new Empresa();
            PermisoUsuario permisoUsuario = new PermisoUsuario();
            InformacionEmpresaActual(usuarioactual, empresaActual, permisoUsuario);

            if (empresaActual.EmpresaID != id)
            {
                return RedirectToAction("Index");
            }

            if (permisoUsuario.PermisoID != 1)
            {
                return RedirectToAction("Index");
            }

            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empresa empresa = db.Empresas.Find(id);

            if (empresa == null)
            {
                return BadRequest();
            }
            // Reemplazar:
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            // Por:
            Localidad localidad = (from cam in db.Localidades where cam.LocalidadID == empresa.LocalidadID && empresa.EmpresaID == 0 select cam).Single();

            //var localidad = (from cam in db.Empresas where cam.LocalidadID == localidad.LocalidadID && (cam.EmpresaID == 0 || cam.EmpresaID == empresa.EmpresaID) select cam).Single();
           // var localidad = (from cam in db.Localidades where cam.LocalidadID == empresa.LocalidadID && (cam.EmpresaID == 0 || cam.EmpresaID == empresa.EmpresaID) select cam).Single();
            ViewBag.LocalidadID = localidad?.LocalidadID;
            ViewBag.LocalidadNombre = localidad?.NombreVista;

            //var tiposContribuyentes = (from o in db.TipoContribuyentes where o.Visible == true select o).ToList();
            //ViewBag.TipoContribuyenteID = new SelectList(tiposContribuyentes.OrderBy(t => t.TipoContribuyenteNombre), "TipoContribuyenteID", "TipoContribuyenteNombre", empresa.TipoContribuyenteID);

            // var tipoDocumentos = (from o in db.TipoDocumentos where o.Visible == true select o).ToList();
            //if (empresa.TipoContribuyenteID == 5)// CONSUMIDOR FINAL.
            //{
            // DNI.
            //    tipoDocumentos = (from o in tipoDocumentos where o.TipoDocumentoID == 96 select o).ToList();
            //}
            //else
            //{
            // CUIT.
            //    tipoDocumentos = (from o in tipoDocumentos where o.TipoDocumentoID == 80 select o).ToList();
            //}
            //ViewBag.TipoDocumentoID = new SelectList(tipoDocumentos.OrderBy(t => t.TipoDocumentoNombre), "TipoDocumentoID", "TipoDocumentoNombre", empresa.TipoDocumentoID);

            //BUSCAR PROVINCIAS CON EMPRESA 0 Y EMPRESA ACTUAL
            var provincias = (from o in db.Provincias where empresa.LocalidadID == localidad.LocalidadID && localidad.ProvinciaID == o.ProvinciaID select o).ToList();

            //var provincias = (from o in db.Provincias where o.EmpresaID == 0 || o.EmpresaID == empresa.EmpresaID select o).ToList();
            ViewBag.ProvinciaID = new SelectList(provincias.Where(p => p.PaisID == 200).OrderBy(p => p.ProvinciaNombre), "ProvinciaID", "ProvinciaNombre");

            return View(empresa);
        }
    }
}
