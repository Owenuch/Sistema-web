using ProyProductoMVC.Data.Interfaces;
using ProyProductoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyProductoMVC.Data {
    public class UsuarioDAO : IUsuario {
        public Usuario Validar(string nombreUsuario, string clave) {
            Usuario usuario = null;

            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Validar_Usuario";
            cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
            cmd.Parameters.AddWithValue("@Contrasena", clave);
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read()) {
                if(usuario == null) {
                    usuario = new Usuario() {
                        Id = Convert.ToInt32(dr["ID"]),
                        Nombre = dr["Nombre"].ToString(),
                        ClaveHash = dr["Clave_Hash"].ToString(),
                        Email = dr["Email"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    };
                }
                Rol rol = new Rol() {
                    Id = Convert.ToInt32(dr["RolID"]),
                    Nombre = dr["NombreRol"].ToString()
                };
                usuario.Roles.Add(rol);
            }

            cnx.Close();

            return usuario;
        }
    }
}