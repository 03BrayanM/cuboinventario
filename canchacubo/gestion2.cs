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
    public partial class gestion2 : Form
    {
        public gestion2()
        {
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            principal inicio = new principal();
            inicio.Show();
            this.Close();
        }

        private void btn_inventario_Click(object sender, EventArgs e)
        {
            Gestion gestiona = new Gestion();
            gestiona.Show();
            this.Hide();
        }

        private void btn_empleado_Click(object sender, EventArgs e)
        {
            empleado emple = new empleado();
            emple.Show();
            this.Hide();
        }
    }
}
