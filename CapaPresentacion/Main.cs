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
    public partial class Main : Form
    {
        CN_Productos obj_CN = new CN_Productos();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MostrarProd();
        }
        public  void MostrarProd()
        {
            dataGridView1.DataSource = obj_CN.MostrarProductos();
        }

        private void bttnAgregarProd_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
            this.Hide();
        }

        private void bttnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
