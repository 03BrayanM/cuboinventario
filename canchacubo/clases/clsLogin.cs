using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canchacubo.clases
{
    internal class clsLogin
    {  
        string usuario;
        string contrasenia;

        public clsLogin(String user, string contra)
        {
            usuario = user;
            contrasenia = contra;
        }
        public string getUsuario()
        {
            return usuario;
        }
        public string getContra()
        {
            return contrasenia;
        }
     public bool ValidarUsuario(string user, string contrasenia)
        {
            string cadenaConexion = "Data Source=localhost; User ID=USUARIO; Password=USER654321;";
            try
            {
                // Validación de datos antes de insertar
                
                    using (OracleConnection connection = new OracleConnection(cadenaConexion))
                    {
                        OracleCommand command = new OracleCommand();
                        command.Connection = connection;
                        command.CommandText = "iniciarSesionn";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = user;
                        command.Parameters.Add("p_contraseña", OracleDbType.Varchar2).Value = contrasenia;

                    connection.Open();
                     command.ExecuteNonQuery();

                }
                    // Retorna true si la inserción fue exitosa
                    return true;
                
            }
            catch (ArgumentException ex)
            {
                // Manejo de excepción de validación
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OracleException ex)
            {
                // Manejo de errores específicos de Oracle
                switch (ex.Number)
                {

                    case 20001:
                        MessageBox.Show($"Error: usuario '{user}' inexistente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20002:
                        MessageBox.Show($"Error: contraseña incorrecta para el usuario '{user}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;                 
                    default:
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                MessageBox.Show("Error al validar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
