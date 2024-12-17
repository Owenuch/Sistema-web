using ProyProductoMVC.Filtros;
using ProyProductoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyProductoMVC.Controllers
{
    public class InicioController : Controller
    {
        [AutenticacionFilter]
        [HttpGet]
        public ActionResult Index()
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            ViewBag.NombreUsuario = usuario.Nombre;
            return View();
        }
    }
}