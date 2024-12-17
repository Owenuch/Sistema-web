using ProyProductoMVC.Data;
using ProyProductoMVC.Filtros;
using ProyProductoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyProductoMVC.Controllers {
    public class CuentaController : Controller {
        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formulario) {
            string nombreUsuario = formulario["txtUsuario"];
            string password = formulario["txtPassword"];

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = usuarioDAO.Validar(nombreUsuario, password);

            if(usuario != null) {
                Session["Usuario"] = usuario;
                //return RedirectToAction("Index", "Inicio");
                return RedirectToAction("Roles");
            }

            ViewBag.Error = "Credenciales inválidas";
            return View();
        }

        [AutenticacionFilter]
        [HttpGet]
        public ActionResult Roles()
        {
            return View(Session["Usuario"] as Usuario);
        }

        [HttpPost]
        public ActionResult Roles(FormCollection formulario)
        {
            string rolElegido = formulario["rolElegido"];
            Session["eRolElegido"] = rolElegido;
            string paginaDestino = "Error404";
            if(rolElegido == "Administrador")
            {
                paginaDestino = "Index";
            }
            else if (paginaDestino == "Gerente") {
                paginaDestino = "Error404";
            }
            else if (paginaDestino == "Vendedor")
            {
                paginaDestino = "Error404";
            }

            return RedirectToAction(paginaDestino, "Inicio");
        }

        [HttpGet]
        public ActionResult Logout() {
            Session.Clear(); // Eliminar datos de sesión
            return RedirectToAction("Login");
        }
    }
}