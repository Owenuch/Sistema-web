using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyProductoMVC.Models {
    public class Rol {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Rol() {
            Id = 0;
            Nombre = string.Empty;
        }

        public Rol(int id, string nombre) {
            Id = id;
            Nombre = nombre;
        }
    }
}