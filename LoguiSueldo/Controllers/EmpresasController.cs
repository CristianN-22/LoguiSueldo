using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoguiSueldo.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Threading;
using System.Globalization;
using LoguiSueldo.Models.Administracion;
using LoguiSueldo.Data;
using Microsoft.CodeAnalysis.Options;
//using Org.BouncyCastle.Crypto.Tls;

namespace LoguiSueldo.Controllers
{
    [Authorize]
    public class EmpresasController : Controller
    {
        private readonly LoguiSueldoContext db;

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
                empresa.TipoContribuyenteID = empresaActual.TipoContribuyenteID;
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
    }
}
