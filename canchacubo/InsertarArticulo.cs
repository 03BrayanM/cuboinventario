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
    public partial class InsertarArticulo : Form
    {
        public event EventHandler ArticuloRegistrado;
        public InsertarArticulo()
        {
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btn_articulo_Click(object sender, EventArgs e)
        {
            String nombre = txtt_nombre.Text;
            string precio = txt_precio.Text;
            String identificador = txt_identificador.Text;
            String descripcion = txt_descripcion.Text;
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(precio) ||
             string.IsNullOrEmpty(identificador) || string.IsNullOrEmpty(descripcion))
            {

                MessageBox.Show("Debe diligenciar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsManager manager = new clsManager();
            bool resultado = manager.Insertararticulo(identificador, nombre, precio, descripcion);
            if (resultado)
            {
                // Si el registro fue exitoso, disparamos el evento ClienteRegistrado
                MessageBox.Show("Articulo registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ArticuloRegistrado?.Invoke(this, EventArgs.Empty); // Dispara el evento si no es null
                this.Close();
            }
        }
    }
}
