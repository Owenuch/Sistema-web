using ProyProductoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyProductoMVC.Data.Interfaces {
    internal interface IUsuario {
        Usuario Validar(string nombreUsuario, string clave);
    }
}
