using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyProductoMVC.Data {
    public class DataBase {
        public static SqlConnection ObtenerConexion() {
            SqlConnectionStringBuilder generadorCadenaCnx = new SqlConnectionStringBuilder();
            generadorCadenaCnx.DataSource = "localhost";
            generadorCadenaCnx.InitialCatalog = "BD_Market";
            generadorCadenaCnx.UserID = "sa";
            generadorCadenaCnx.Password = "sql";
            string cadenaCnx = generadorCadenaCnx.ToString();

            SqlConnection conexion = new SqlConnection(cadenaCnx);

            return conexion;
        }
    }
}