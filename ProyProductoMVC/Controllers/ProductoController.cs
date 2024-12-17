using ProyProductoMVC.Data;
using ProyProductoMVC.Filtros;
using ProyProductoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyProductoMVC.Controllers {


    [AutenticacionFilter]
    public class ProductoController : Controller {
        private readonly ProductoDAO _productodao = new ProductoDAO(); // Instancia del DAO

        [HttpGet]
        public ActionResult Index() {
            Usuario usuario = Session["Usuario"] as Usuario;
            ViewBag.NombreUsuario = usuario.Nombre;
            List<Producto> listaProductos = new List<Producto>();
            return View(listaProductos);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formulario) {
            Usuario usuario = Session["Usuario"] as Usuario;
            ViewBag.NombreUsuario = usuario.Nombre;
            string descripcionBuscar = formulario["txtDescripcion"];
            ProductoDAO productoDAO = new ProductoDAO();
            List<Producto> listaProductos = productoDAO.BuscarPorDescripcion(descripcionBuscar);
            return View(listaProductos);
        }

        public ActionResult Crear()
        {
            return View();  // Vista vacía para agregar cliente
        }
        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productodao.Insertar(producto);  // Llama al DAO para agregar el cliente
                    return RedirectToAction("Index");  // Redirige a la lista de clientes
                }

                return View(producto);  // Si el modelo no es válido, permanece en la vista
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al agregar el cliente: " + ex.Message;
                return View(producto);  // Si hay error, se muestra el mensaje
            }
        }
        public ActionResult Editar(int id)
        {
            try
            {
                
                Producto producto = _productodao.ObtenerProductos( ).Find(c => c.Id == id);

                if (producto == null)
                {
                    return HttpNotFound();
                }

                return View(producto);  
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al obtener el cliente para editar: " + ex.Message;
                return View();
            }
        }

        // POST: Cliente/Editar - Actualizar 
        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productodao.Actualizar(producto);  
                    return RedirectToAction("Index");  
                }

                return View(producto); 
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al actualizar el cliente: " + ex.Message;
                return View(producto);  
            }
        }
    }
}