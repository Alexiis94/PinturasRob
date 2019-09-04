using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class Productos : Form
    {
        CN_Productos obj_CN = new CN_Productos();
        private string idprod = null;
        private bool editar = false;
        public Productos()
        {
            InitializeComponent();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            ListarCategoria();

        }
        public void MostrarProductos()
        {
            CN_Productos obj = new CN_Productos();
            dataGridView1.DataSource = obj.MostrarProductos(); // usamos el metodo creado en la capa CN.
        }
        private void ListarCategoria()
        {

            cmbCategoria.DataSource = obj_CN.MostrarCategoria();
            cmbCategoria.DisplayMember = "descripcion";
            cmbCategoria.ValueMember = "cod_categoria";
            cmbCategoria.Text = "Selecciones una Categoria";
            //categor = cmbCategoria.SelectedValue.ToString();
        }

        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            // se creo una condicion si editar es false entonces agregara , pero si editar es true. 
            if (editar == false)
            {
                try
                {
                    
                    obj_CN.InsertarProd(txtNombre.Text, txtPrecio.Text, txtStock.Text, cmbCategoria.SelectedValue.ToString());

                    MessageBox.Show("Ingresado");
                    MostrarProductos();
                    limpiarForm();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al Ingresar " + ex);
                }
            }
            // si la condicion resulta true  se podra editar.
            if(editar == true)
            {
                try
                {
                    obj_CN.EditarProd(txtNombre.Text, txtPrecio.Text, txtStock.Text, cmbCategoria.SelectedValue.ToString(), idprod);
                    MessageBox.Show("Fila fue Editada exitosamente.");
                    MostrarProductos();
                    limpiarForm();
                    editar = false; // se desactiva para que el bttnGuardar pueda agregar registros y no continue editando.
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al Editar " + ex);
                } 
            }
        }

        private void bttnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["stock"].Value.ToString();
                cmbCategoria.SelectedValue = dataGridView1.CurrentRow.Cells["cod_categoria"].Value.ToString();
                idprod = dataGridView1.CurrentRow.Cells["id_producto"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un fila por favor");
            }
        }
         
        private void limpiarForm()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.Text = "Selecciones una Categoria";
        }

        private void bttnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                idprod = dataGridView1.CurrentRow.Cells["id_producto"].Value.ToString();
                obj_CN.EliminarProd(idprod);
                MessageBox.Show("Producto Eliminado");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Error al Eliminar Producto.");
            }

        }

        private void bttnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bttnVolver_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
