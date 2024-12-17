using ProyProductoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyProductoMVC.Data.Interfaces {
    internal interface IProducto {
        // Métodos CRUD
        List<Producto> ObtenerProductos();

        void Insertar(Producto producto);    // Create
        Producto BuscarPorId(int id);       // Read
        void Actualizar(Producto producto); // Update
        bool Eliminar(int id);              // Delete

        // Métodos Adicionales
        List<Producto> BuscarPorDescripcion(string descripcion);
    }
}
