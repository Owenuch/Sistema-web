using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyProductoMVC.Filtros {
    public class AutenticacionFilter : ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext contextoFiltro) {
            // Verificar si el usuario esta en sesión
            if(HttpContext.Current.Session["Usuario"] == null) {
                // Redirigir al login si la sesión no está activa
                contextoFiltro.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                        { "controller", "Cuenta" },
                        { "action", "Login" }
                    }
                );
            }
            base.OnActionExecuted(contextoFiltro);
        }
    }
}