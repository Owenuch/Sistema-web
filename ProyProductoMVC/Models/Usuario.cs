using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyProductoMVC.Models {
    public class Usuario {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ClaveHash { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
        public List<Rol> Roles { get; set; }

        public Usuario() {
            Id = 0;
            Nombre = string.Empty;
            ClaveHash = string.Empty;
            Email = string.Empty;
            Estado = false;
            Roles = new List<Rol>();
        }

        public Usuario(int id, string nombre, string claveHash, string email, bool estado) {
            Id = id;
            Nombre = nombre;
            ClaveHash = claveHash;
            Email = email;
            Estado = estado;
            Roles = new List<Rol>();
        }

        public Usuario(int id, string nombre, string claveHash, string email, bool estado, List<Rol> roles) {
            Id = id;
            Nombre = nombre;
            ClaveHash = claveHash;
            Email = email;
            Estado = estado;
            Roles = roles;
        }

        public bool IsNombreRol(string nombreRol) {
            return Roles.Any(rol => rol.Nombre.Equals(nombreRol, StringComparison.OrdinalIgnoreCase));
        }
    }
}