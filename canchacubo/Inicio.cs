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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            txt_contraseña.PasswordChar = '*'; // Establece el carácter para ocultar la contraseña
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {           
            string usuario = txt_usuario.Text.ToString();
            string contraseña = txt_contraseña.Text.ToString(); ;
            if (string.IsNullOrEmpty(usuario)|| string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor rellene los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsLogin usar = new clsLogin(usuario,contraseña);          
           Boolean resultado = usar.ValidarUsuario(usuario, contraseña);
            if (resultado)
            {
                rol.Name = usuario.ToUpper();
                rol.password = contraseña;
                principal iniciar = new principal();
                iniciar.Show();
                this.Hide();

            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
