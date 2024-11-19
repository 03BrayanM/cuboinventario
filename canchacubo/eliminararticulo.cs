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
    public partial class eliminararticulo : Form
    {
        public event EventHandler ArticuloEliminado;
        public eliminararticulo()
        {
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            String identificador = txt_identificador.Text;
           
            if (string.IsNullOrEmpty(identificador) )
            {

                MessageBox.Show("Debe diligenciar el los campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsManager manager = new clsManager();
            bool resultado = manager.Eliminarticulo(identificador);
            if (resultado)
            {
                // Si el registro fue exitoso, disparamos el evento ClienteRegistrado
                MessageBox.Show("Articulo Eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ArticuloEliminado?.Invoke(this, EventArgs.Empty); // Dispara el evento si no es null
                this.Close();
            }
        }
    }
}
