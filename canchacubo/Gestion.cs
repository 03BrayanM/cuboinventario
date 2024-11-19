using canchacubo.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canchacubo
{
    public partial class Gestion : Form
    {
        clsManager manager = new clsManager();
        DataTable dtinventario;
        public Gestion()
        {
            InitializeComponent();
            CargarInventarioDataGreatView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            principal inicio = new principal();
            inicio.Show();
            this.Close();
        }
        private void RecargarDatosInventario()
        {
            try
            {
                dtinventario = manager.obtenerTablaInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarInventarioDataGreatView()
        {
            RecargarDatosInventario();
            dgvinventario.DataSource = dtinventario; // Enlazar los datos al DataGridView
        }
    }
}
