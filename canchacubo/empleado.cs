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
    public partial class empleado : Form
    {
        DataTable dtinventario;
        clsManager manager = new clsManager();
        public empleado()
        {
            InitializeComponent();
            CargarInventarioDataGreatView("0");
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            gestion2 inicio = new gestion2();
            inicio.Show();
            this.Close();
        }
        private void RecargarDatosInventario(string valor)
        {
            try
            {
                    dtinventario = manager.obtenerTablaEmpleado(valor);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarInventarioDataGreatView(string valor)
        {
            RecargarDatosInventario( valor);
            dgv_empleado.DataSource = dtinventario; // Enlazar los datos al DataGridView
        }

        private void cbxopciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string horaStr = cbxopciones.SelectedItem.ToString();
            CargarInventarioDataGreatView(horaStr);

        }
    }
}
