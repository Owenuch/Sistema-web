using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyProductoMVC.Models {
    public class Producto {
        private int id;
        public int Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }
        public string CodigoInventario { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public Producto() {
            Id = 0;
            CodigoInventario = string.Empty;
            Descripcion = string.Empty;
            Categoria = string.Empty;
            Precio = 0.0;
            Stock = 0;
        }

        public Producto(int id, string codigoInventario, string descripcion, string categoria, double precio, int stock) {
            Id = id;
            CodigoInventario = codigoInventario;
            Descripcion = descripcion;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
        }
    }
}