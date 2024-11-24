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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace canchacubo
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
            // Verifica uma condição qualquer
            if (rol.Name == "ADMIN")
            {
                // Se a condição for verdadeira, oculta o botão
                btn_gestion.Visible = true;
            }
            else
            {
                // Se a condição for falsa, mostra o botão
                btn_gestion.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void b_usuario_Click(object sender, EventArgs e)
        {
            cliente clientes = new cliente() ;
            clientes.Show(); // 
             this.Hide(); 
        }

        private void btn_reserva_Click(object sender, EventArgs e)
        {
            reservas reserva = new reservas();
            reserva.Show();
            this.Hide();

        }

        private void btn_promociones_Click(object sender, EventArgs e)
        {
            promociones promo = new promociones();
            promo.Show();
            this.Hide();
        }

        private void btn_gestion_Click(object sender, EventArgs e)
        {
            
            gestion2 gestiona = new gestion2();
            gestiona.Show();
            this.Hide();
        }
    }
}
