using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objCD = new CD_Productos(); //instanciamos a clase CD_productos

        public DataTable MostrarProductos()
        {

            DataTable tabla = new DataTable(); // guardamos los registros de la tabla que devuelve los datos.
            tabla = objCD.mostrar();
            return tabla;
        }

        public DataTable MostrarCategoria()
        {

            DataTable tablaCat = new DataTable();
            tablaCat = objCD.mostrarCategoria();
            return tablaCat;

        }

        public void InsertarProd(string Nombre, string Precio, string Stock, string Categoria)
        {
            objCD.InsertarProducto(Nombre, Convert.ToDouble(Precio), Convert.ToInt32(Stock), Convert.ToInt32(Categoria));
        }
        //editar
        public void EditarProd(string Nombre, string Precio, string Stock, string Categoria, string id)
        {
            objCD.editarProducto(Nombre, Convert.ToDouble(Precio), Convert.ToInt32(Stock), Convert.ToInt32(Categoria), Convert.ToInt32(id));
        }
        //Eliminar
        public void EliminarProd(string id)
        {
            objCD.eliminarProducto(Convert.ToInt32(id));
        }
    }
} 


