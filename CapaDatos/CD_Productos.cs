using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class CD_Productos
    {
        public string IdProd { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Stock { get; set; }
        public string Categoria { get; set; }

        public CD_Productos(string id, string nombre, string precio, string stock, string categoria)
        {
            this.IdProd = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Stock = stock;
            this.Categoria = categoria;
        }
        public CD_Productos()
        {

        }


        private CD_Conexion conexion = new CD_Conexion(); // encapsular variable

        SqlDataReader leer; // leer las filas de la tabla productos
        DataTable tabla = new DataTable(); // almacenar las consultas de data readerDataTable tabla = new DataTable(); // almacenar las consultas de data reader
        DataTable tabla2 = new DataTable(); // almacenar las consultas de data reader
        SqlCommand comando = new SqlCommand(); // ejecutar comandos Sql

        public DataTable mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            // comando.CommandText = "Select * from Producto"; // Query
            comando.CommandText = "MostrarProductos"; // nombre del procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader(); // guardamos el valor de la Query - Procedimiento creada en comand.Text
            tabla.Load(leer);
            comando.Connection = conexion.CerrarConexion();
            return tabla;
        }
        public DataTable mostrarCategoria()
        {
            comando.Connection = conexion.AbrirConexion();
            // comando.CommandText = "Select * from Producto"; // Query
            comando.CommandText = "MostrarCategoria"; // nombre del procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader(); // guardamos el valor de la Query - Procedimiento creada en comand.Text
            tabla2.Load(leer);
            leer.Close();
            comando.Connection = conexion.CerrarConexion();
            return tabla2;
        }
        public void InsertarProducto(string Nombre, double Precio, int Stock, int Categoria)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@precio", Precio);
            comando.Parameters.AddWithValue("@stock", Stock);
            comando.Parameters.AddWithValue("@codCategoria", Categoria);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            
        }
        public  void editarProducto(string Nombre, double Precio, int Stock, int Categoria, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@precio", Precio);
            comando.Parameters.AddWithValue("@stock", Stock);
            comando.Parameters.AddWithValue("@codCategoria", Categoria);
            comando.Parameters.AddWithValue("@idProducto", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void eliminarProducto(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProducto", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
