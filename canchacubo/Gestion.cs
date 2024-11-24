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
        int ProductoSeleccionado;

        public event EventHandler MovimientoExitoso;         
        public Gestion()
        {
            InitializeComponent();
            CargarInventarioDataGreatView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestion2 inicio = new gestion2();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (ProductoSeleccionado==null)
            {

                MessageBox.Show("Debe seleccionar un artiuclo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.MovimientoExitoso += RefrescarInventario;
            clsManager manager = new clsManager();
            bool resultado = manager.Eliminarticulo(ProductoSeleccionado.ToString());
            if (resultado)
            {
                // Si el registro fue exitoso, disparamos el evento ClienteRegistrado
                MessageBox.Show("Articulo Eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MovimientoExitoso?.Invoke(this, EventArgs.Empty); // Dispara el evento si no es null

            }
            
         
            }

        public void RefrescarInventario(object sender, EventArgs e)
        {
            CargarInventarioDataGreatView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertarArticulo Form_articulo = new InsertarArticulo();
            Form_articulo.ArticuloRegistrado += RefrescarInventario;
            Form_articulo.Show();
        }
       
        private void actualizar_Click(object sender, EventArgs e)
        {
            string cantidad = txt_cantidad.Text;
            string tipo = cbx_tipo.SelectedItem.ToString();
            if (string.IsNullOrEmpty(cantidad))
            {
                MessageBox.Show("Por favor ingrese una cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbx_tipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un tipo de actualizacion.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.MovimientoExitoso += RefrescarInventario;
            bool resultado = manager.actualizarstock(ProductoSeleccionado, tipo, cantidad);
            if (resultado)
            {
                MessageBox.Show("Movimiento exitoso. ", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MovimientoExitoso?.Invoke(this, EventArgs.Empty); // Dispara el evento si no es null
                
            }
        }

        private void dgvinventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (dgvinventario.SelectedRows.Count > 0)
            {
                ProductoSeleccionado = Convert.ToInt32(dgvinventario.SelectedRows[0].Cells["Identificador"].Value);
                txtbuscar.Text = ProductoSeleccionado.ToString();
            }
        }
    }
}
