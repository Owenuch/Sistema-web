using ProyProductoMVC.Data.Interfaces;
using ProyProductoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyProductoMVC.Data
{
    public class ProductoDAO : IProducto
    {
        public void Insertar(Producto producto)
        {
            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();

            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_InsertarProducto";

            cmd.Parameters.AddWithValue("@Codigo_inventario", producto.CodigoInventario);
            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@Categoria_ID", producto.Categoria);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Stock", producto.Stock);

            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public Producto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Producto producto)
        {
            {
                try
                {
                    using (SqlConnection conexion = DataBase.ObtenerConexion())
                    {
                        conexion.Open();

                        using (SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Parámetros para actualizar un cliente
                            cmd.Parameters.AddWithValue("@ID", producto.Id);
                            cmd.Parameters.AddWithValue("@Codigo_inventario", producto.CodigoInventario);
                            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                            cmd.Parameters.AddWithValue("@Categoria_ID", producto.Categoria);
                            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                            cmd.Parameters.AddWithValue("@Stock", producto.Stock);


                            cmd.ExecuteNonQuery(); // Ejecutar el comando
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el cliente: " + ex.Message);
                }
            }
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> BuscarPorDescripcion(string descripcion)
        {
            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_BuscarProductoPorDescripcion";
            cmd.Parameters.AddWithValue("@DescripcionBuscar", descripcion);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Producto> listaProductos = new List<Producto>();
            while (dr.Read())
            {
                Producto producto = new Producto()
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    CodigoInventario = dr["Codigo_inventario"].ToString(),
                    Descripcion = dr["Descripcion"].ToString(),
                    Categoria = dr["CategoriaNombre"].ToString(),
                    Precio = Convert.ToInt32(dr["Precio"]),
                    Stock = Convert.ToInt32(dr["Stock"])
                };
                listaProductos.Add(producto);
            }
            cnx.Close();
            return listaProductos;
        }

        public List<Producto> ObtenerProductos()
        {
            {
                List<Producto> producto = new List<Producto>();

                try
                {
                    using (SqlConnection conexion = DataBase.ObtenerConexion())
                    {
                        conexion.Open();

                        using (SqlCommand cmd = new SqlCommand("sp_listar_clientes", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlDataReader dr = cmd.ExecuteReader();
                            {
                                while (dr.Read())
                                {
                                    Producto productos = new Producto
                                    {
                                        Id = Convert.ToInt32(dr["ID"]),
                                        CodigoInventario = dr["Codigo_inventario"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        Categoria = dr["CategoriaNombre"].ToString(),
                                        Precio = Convert.ToInt32(dr["Precio"]),
                                        Stock = Convert.ToInt32(dr["Stock"])
                                    };
                                    producto.Add(productos);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los clientes: " + ex.Message);
                }

                return producto;
            }
        }
    }
}

